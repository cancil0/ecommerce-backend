using Core.Abstract;
using Core.Extension;
using Core.IoC;
using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Concrete
{
    public class TokenService : ITokenService
    {
        public async Task<string> GenerateToken(User user, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var key = Encoding.UTF8.GetBytes(Provider.Configuration["JwtSettings:Secret"]);
            var secret = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                            {
                                new Claim("id", user.UserId.ToString()),
                                new Claim("email", user.Email),
                                new Claim("userName", user.UserName),
                                new Claim("name", string.Format("{0} {1}", user.Name, user.SurName))
                            };

            foreach (var userRole in user.UserRoles)
            {
                claims.Add(new Claim("roles", userRole.Role.RoleName));
            }

            var expires = Provider.Configuration["JwtSettings:AccessTokenExpiration"].ToInt();

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(expires));

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(tokenOptions));
        }

        public async Task<bool> IsTokenValid(string token, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var key = Provider.Configuration["JwtSettings:Secret"];
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
