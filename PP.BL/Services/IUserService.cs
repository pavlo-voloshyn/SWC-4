using PP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.BL.Services
{
    public interface IUserService
    {
        public Task RegisterUser(User user);

        public Task<string> Login(string username, string password);

        public Task<User> GetUser();
    }
}
