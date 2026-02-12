using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            var result = await _authservice.LoginAsync(login);

            if (result != null) // Check if login was successful
            {
                // Cookie options set karein
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,   // JavaScript access nahi kar sakega (Secure)
                    Secure = true,     // Sirf HTTPS par kaam karega
                    SameSite = SameSiteMode.Strict, // CSRF protection
                    Expires = DateTime.UtcNow.AddDays(1) // Token ki expiry ke mutabiq
                };

                // "AuthToken" ke naam se cookie set karein
                Response.Cookies.Append("AuthToken", result, cookieOptions);

                return Ok(new { message = "Login Successful" });
            }

            return Unauthorized();
        }
        [HttpGet("Auth-endpoint")]
       [Authorize(Roles = nameof(RoleType.User))]
        public async Task<IActionResult> AuthCheck()
        {
            return Ok();
        }
    }
}

