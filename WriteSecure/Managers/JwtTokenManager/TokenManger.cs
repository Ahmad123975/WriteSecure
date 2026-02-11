using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WriteSecure.Models;

namespace WriteSecure.Managers.JwtTokenManager
{
    public class TokenManger : ITokenManager
    {
        private readonly IConfiguration _configuration;
        public TokenManger(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateToken(User user)
        {
            var cliams = new List<Claim>
           {
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Name,user.Username),
               new Claim(ClaimTypes.Role,user.Role.ToString()),
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSetting:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                issuer:_configuration.GetValue<string>("AppSetting:Issuer"),
                audience:_configuration.GetValue<string>("AppSetting:Audience"),
                claims:cliams,
                expires:DateTime.UtcNow.AddDays(1),
                signingCredentials:creds

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
