using Microsoft.AspNetCore.Mvc;
using LicenseSalesApp.DTOs;
using LicenseSalesApp.Services;
using System.Threading.Tasks;

namespace LicenseSalesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var response = await _userService.RegisterAsync(userDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var response = await _userService.LoginAsync(userDto);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }

        // Additional methods for managing users
    }
}
