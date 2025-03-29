using ApiProducts.Application.Interfaces;
using ApiProducts.Application.Services;
using ApiProducts.Domain.Entities;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;

namespace ApiProducts.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly UserService _userService;

        public AuthController(AuthService authService, UserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginRequest loginRequest)
        //{
        //    // Aquí deberías validar las credenciales con un repositorio o servicio
        //    var user = ValidateUser(loginRequest.Username, loginRequest.Password);

        //    if (user == null)
        //        return Unauthorized("Invalid credentials");

        //    var token = _authService.GenerateToken(user);
        //    return Ok(new { Token = token });
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
  
            var user = await _userService.GetByUsernameAsync(loginRequest.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _authService.GenerateToken(user);
            return Ok(new { Token = token });
        }


        //private User ValidateUser(string username, string password)
        //{
        //    // Aquí puedes buscar al usuario en la base de datos para validarlo
        //    // Este es solo un ejemplo simple de validación.
        //    if (username == "usuario_prueba" && password == "123456")
        //    {
        //        return new User
        //        {
        //            Id = 1,
        //            Username = username
        //        };
        //    }
        //    return null;
        //}
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
