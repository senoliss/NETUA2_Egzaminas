using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NETUA2_Egzaminas.API.Interfaces;

namespace NETUA2_Egzaminas.API.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetJwtToken(int userId, string userName)
        {
            var secretKey = _configuration.GetSection("Jwt:Key").Value;
            var issuer = _configuration.GetSection("Jwt:Issuer").Value;
            var audience = _configuration.GetSection("Jwt:Audience").Value;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
