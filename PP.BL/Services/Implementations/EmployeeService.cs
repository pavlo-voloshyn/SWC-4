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
    public class EmployeeService : IEmployeeService
    {
        private readonly PassportPointDbContext _context;
        private readonly IMapper mapper;

        public EmployeeService(PassportPointDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task Create(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id = {id} not found");
            }
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new ArgumentException($"Employee with id = {id} not found");
            }
            return employee;
        }

        public async Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task RemoveOrder(int orderId, int employeeId)
        {
            var employeeOrder = _context.EmployeeOrders.FirstOrDefault(eo => eo.OrderId == orderId && eo.EmployeeId == employeeId);
            _context.Remove(employeeOrder);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrder(int orderId, int employeeId)
        {
            _context.Add(new EmployeeOrder() { EmployeeId = employeeId, OrderId = orderId });
            await _context.SaveChangesAsync();
        }
        public async Task Update(Employee employee)
        {
            var employeeToUpdate = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (employeeToUpdate == null)
            {
                throw new ArgumentException($"Employee with id = {employee.Id} not found");
            }
            mapper.Map(employee, employeeToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}
