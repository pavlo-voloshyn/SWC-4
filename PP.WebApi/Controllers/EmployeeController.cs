using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PP.BL.Services;
using PP.DAL.Models;
using PP.WebApi.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PP.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInsert employeeInsert)
        {
            var employee = _mapper.Map<Employee>(employeeInsert);
            await _employeeService.Create(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(EmployeeUpdate employeeUpdate)
        {
            var employee = _mapper.Map<Employee>(employeeUpdate);
            await _employeeService.Update(employee);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }

        [HttpPut("remove-order")]
        public async Task<IActionResult> RemoveOrder(int orderId, int employeeId)
        {
            await _employeeService.RemoveOrder(orderId, employeeId);
            return Ok();
        }

        [HttpPut("add-order")]
        public async Task<IActionResult> AddOrder(int orderId, int employeeId)
        {
            await _employeeService.AddOrder(orderId, employeeId);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.Get(id);
            return Ok(_mapper.Map<EmployeeView>(employee));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAll();
            return Ok(_mapper.Map<IList<EmployeeView>>(employees));
        }
    }
}
