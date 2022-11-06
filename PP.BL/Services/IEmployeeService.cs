using PP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.BL.Services
{
    public interface IEmployeeService
    {
        public Task<IList<Employee>> GetAll();

        public Task<Employee> Get(int id);

        public Task Update(Employee employee);

        public Task Delete(int id);

        public Task Create(Employee employee);

        public Task RemoveOrder(int orderId, int employeeId);

        public Task AddOrder(int orderId, int employeeId);

    }
}
