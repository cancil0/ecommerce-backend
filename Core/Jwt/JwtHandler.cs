using Core.Extension;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Jwt
{
    public class JwtHandler : ITokenHelper
    {
        public string GenerateToken(User user, IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]);
            var secret = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                            {
                                new Claim("id", user.UserId.ToString()),
                                new Claim("email", user.Email),
                                new Claim("userName", user.UserName),
                            };

            foreach (var userRole in user.UserRoles)
            {
                claims.Add(new Claim("roles", userRole.Role.RoleName));
            }

            var expires = configuration["JwtSettings:AccessTokenExpiration"].ToInt();
            var issuer = configuration["JwtSettings:Issuer"];
            var audience = configuration["JwtSettings:Audience"];

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(expires),
                issuer: issuer,
                audience: audience);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        public bool IsTokenValid(string key, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
