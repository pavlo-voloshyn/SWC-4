using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PP.DAL;
using PP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.BL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly PassportPointDbContext _context;
        private readonly IMapper mapper;

        public OrderService(PassportPointDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task Create(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(e => e.Id == id);
            if (order == null)
            {
                throw new ArgumentException($"Order with id = {id} not found");
            }
            _context.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> Get(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                throw new ArgumentException($"Order with id = {id} not found");
            }
            return order;
        }

        public async Task<IList<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task Update(Order order)
        {
            var orderToUpdate = _context.Orders.FirstOrDefault(e => e.Id == order.Id);
            if (orderToUpdate == null)
            {
                throw new ArgumentException($"Employee with id = {order.Id} not found");
            }
            mapper.Map(order, orderToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Order>> GetEmployeeOrders(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id = {employeeId} not found");
            }

            var orderIds = _context.EmployeeOrders.Where(eo => eo.EmployeeId == employeeId).Select(eo => eo.OrderId);

            return await _context.Orders.Where(o => orderIds.Contains(o.Id)).ToListAsync();
        }
    }
}
