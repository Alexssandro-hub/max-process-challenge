using JwsAuthApi.DTOs.Requests;
using JwtAuthApi.Core.Interfaces;
using JwtAuthApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwsAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly EncryptPassService _encryptPassService;
        private readonly IUsuarioService _usuarioService;

        public AuthController(JwtService jwtService, IUsuarioService usuarioService, EncryptPassService encryptPassService)
        {
            _jwtService = jwtService;
            _usuarioService = usuarioService;
            _encryptPassService = encryptPassService;
        }

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] LoginRequest request)
        {
            var user = _usuarioService.GetByLogin(request.Username);

            if (user == null || user.Senha != _encryptPassService.Encrypt(request.Password))
                return Unauthorized("Usuário ou senha inválidos");

            var token = _jwtService.GenerateToken(user.Login);
            return Ok(new { token });
        }
    }
}
