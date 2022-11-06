using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PP.BL.Services;
using PP.DAL.Models;
using PP.WebApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderInsert orderInsert)
        {
            var order = _mapper.Map<Order>(orderInsert);
            await _orderService.Create(order);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(OrderUpdate orderUpdate)
        {
            var order = _mapper.Map<Order>(orderUpdate);
            await _orderService.Update(order);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.Get(id);
            return Ok(_mapper.Map<OrderView>(order));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();
            return Ok(_mapper.Map<IList<OrderView>>(orders));
        }

        [HttpGet("/employee/{id}")]
        public async Task<IActionResult> GetByEmployee(int id)
        {
            var order = await _orderService.GetEmployeeOrders(id);
            return Ok(_mapper.Map<IList<OrderView>>(order));
        }
    }
}
