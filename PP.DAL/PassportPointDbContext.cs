using Microsoft.EntityFrameworkCore;
using PP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.DAL
{
    public class PassportPointDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<EmployeeOrder> EmployeeOrders { get; set; }

        public DbSet<User> Users { get; set; }

        public PassportPointDbContext(DbContextOptions<PassportPointDbContext> options) : base(options)
        {
        }
    }
}
