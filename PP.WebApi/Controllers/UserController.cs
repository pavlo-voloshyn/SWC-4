using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PP.BL.Services;
using PP.DAL.Models;
using PP.WebApi.ViewModels;
using System.Threading.Tasks;

namespace PP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string username, string password)
        {
            var token = await _userService.Login(username, password);
            return Ok(new { token });
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserInsert userInsert)
        {
            var user = _mapper.Map<User>(userInsert);
            await _userService.RegisterUser(user);
            return Ok();
        }
    }
}
