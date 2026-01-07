using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static MdmApi.Controllers.AuthController;

namespace MdmApi.Repository
{
    public class JwtTokenService
    {
        private readonly IConfiguration _config;
        public JwtTokenService(IConfiguration config) => _config = config;

        public string GenerateAccessToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiresIn"])), // short-lived
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken(string username, string ipAddress)
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
                Expires = DateTime.UtcNow.AddDays(7), // long-lived
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress,
                UserName = username
            };
        }
        public class RefreshToken
        {
            public string Token { get; set; }
            public DateTime Expires { get; set; }
            public bool IsExpired => DateTime.UtcNow >= Expires;
            public DateTime Created { get; set; }
            public string CreatedByIp { get; set; }
            public string UserName { get; set; }
        }
    }


}
