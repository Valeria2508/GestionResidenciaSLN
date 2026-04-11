using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestionResidenciaApi.Data;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public record LoginRequest(string Username, string Password);
        public record AuthResponse(string Token, DateTime Expires);

        // POST: api/Auth
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request is null || string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Username and password are required.");

            var user = await _context.Usuario.SingleOrDefaultAsync(u => u.Username == request.Username && u.Activo);
            if (user is null)
                return Unauthorized("Invalid credentials");

            // Simple password check: accept if stored PasswordHash equals provided password
            // or if SHA256(provided) equals stored PasswordHash (common hashed storage).
            bool passwordValid = false;
            if (user.PasswordHash == request.Password)
            {
                passwordValid = true;
            }
            else
            {
                using var sha = System.Security.Cryptography.SHA256.Create();
                var hashedBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(request.Password));
                var hashedString = BitConverter.ToString(hashedBytes).Replace("-", "");
                if (string.Equals(hashedString, user.PasswordHash, StringComparison.OrdinalIgnoreCase))
                    passwordValid = true;
            }

            if (!passwordValid)
                return Unauthorized("Invalid credentials");

            var key = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured");
            var issuer = _configuration["Jwt:Issuer"] ?? "";
            var audience = _configuration["Jwt:Audience"] ?? "";
            var expireMinutesStr = _configuration["Jwt:ExpireMinutes"] ?? "0";
            int.TryParse(expireMinutesStr, out var expireMinutes);
            if (expireMinutes <= 0) expireMinutes = 60;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("roleId", user.RolId.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(expireMinutes);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return Ok(new AuthResponse(token, expires));
        }
    }
}
