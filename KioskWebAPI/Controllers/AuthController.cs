using KioskWebAPI.Interfaces;
using KioskWebAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace KioskWebAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {            
            var result = await _authService.LoginUserAsync(request.Username, request.Password);

            if (result.Status == "Success")
            {
                return Ok(new { result.Status, result.UserId, result.Username });
            }
            else
            {
                return Unauthorized(new { result.Status, Message = "Invalid credentials" });
            }
        }
    }
}
