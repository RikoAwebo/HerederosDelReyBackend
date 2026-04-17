using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HerederosDelReyBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _authService.LoginAsync(dto);

            if (response == null)
            {
                return Unauthorized(new
                {
                    mensaje = "Email o contraseña incorrectos"
                });
            }

            return Ok(response);
        }
    }
}

