using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Dtos.Request;
using StudentRecordSystem.Services.Interfaces;

namespace StudentRecordSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto registerUserDto)
        {
            var response = await authService.RegisterUserAsync(registerUserDto);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDto loginDto)
        {
            var response = await authService.LoginAsync(loginDto);
            if (response.Success)
            {
                return Ok(response);
            }
            return Unauthorized(response);
        }
    }
}
