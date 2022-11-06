using PP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.BL.Services
{
    public interface IOrderService
    {
        public Task<IList<Order>> GetAll();

        public Task<Order> Get(int id);

        public Task Update(Order order);

        public Task Delete(int id);

        public Task Create(Order order);

        public Task<IList<Order>> GetEmployeeOrders(int employeeId);
    }
}
