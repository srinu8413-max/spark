using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Queuesbooking.Model;
using Queuesbooking.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Queuesbooking.service
{
    public class Auth
    {
        private readonly AppDbcontext _context;
        private readonly IConfiguration _config;

        public Auth(AppDbcontext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // 🔵 LOGIN METHOD
        public async Task<string?> LoginAsync(Login request)
        {
            var user = await _context.user
                .FirstOrDefaultAsync(x => x.Username == request.Username);

            if (user == null)
                return null;

            // ✅ Plain password comparison (NO BCrypt)
            if (user.Password != request.Password)
                return null;

            // 🔑 Generate Token
            return CreateToken(user);
        }

        // 🔑 TOKEN GENERATION
        private string CreateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}