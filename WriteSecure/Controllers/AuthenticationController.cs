using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriteSecure.Common;
using WriteSecure.DTOs;
using WriteSecure.Managers;

namespace WriteSecure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthManager _authservice; 
        public AuthenticationController(IAuthManager authservice)
        {
            _authservice = authservice;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> CreateUser(UserDto dto)
        {
           return Ok(await  _authservice.CreateUserAsync(dto));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            return Ok(await _authservice.LoginAsync(login));
        }
        [HttpGet("Auth-endpoint")]
       [Authorize(Roles = nameof(RoleType.User))]
        public async Task<IActionResult> AuthCheck()
        {
            return Ok();
        }
    }
}

