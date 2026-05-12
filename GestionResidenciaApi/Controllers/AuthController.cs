using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionResidenciaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUsuario _usuarioService; // Inyectamos la interfaz

        public AuthController(JwtService jwtService, IUsuario usuarioService)
        {
            _jwtService = jwtService;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            // Validamos contra la base de datos real
            var usuario = await _usuarioService.ValidarUsuarioAsync(login.Usuario, login.Password);

            if (usuario != null)
            {
                // Si existe, generamos el token usando su Username real
                var token = _jwtService.GenerarToken(usuario.Username);
                return Ok(new { token });
            }

            return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
        }
    }
}
