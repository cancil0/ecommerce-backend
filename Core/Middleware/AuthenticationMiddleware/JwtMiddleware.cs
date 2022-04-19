using Autofac;
using Core.IoC;
using Core.Middleware.ExceptionMiddleware;
using Entities.Concrete;
using Entities.Dto.ResponseDto.ApiRoleResponse;
using Entities.Enums;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Core.Middleware.AuthenticationMiddleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        private readonly IMemoryCache cache;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
            cache = Provider.Resolve<IMemoryCache>();
        }

        public async Task Invoke(HttpContext context)
        {
            /*var contextEndPoint = context.GetEndpoint().Metadata.Select(x => x.GetType()).FirstOrDefault(x => x.Name == "AllowAnonymousAttribute");

            if (contextEndPoint == null)
            {
                CheckToken(context);
            }*/
            await next(context);
        }

        private void CheckToken(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault();
                if (string.IsNullOrEmpty(token))
                {
                    throw new AppException("Please enter a token", ExceptionTypes.NotFound.GetValue());
                }
                token = token.Split(" ").Last();
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration["JwtSettings:Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                    
                var jwtToken = (JwtSecurityToken)validatedToken;

                UserInfoToken user = new() 
                {
                    Email = jwtToken.Claims.First(x => x.Type == "email").Value,
                    UserName = jwtToken.Claims.First(x => x.Type == "userName").Value,
                    Id = jwtToken.Claims.First(x => x.Type == "id").Value,
                    Roles = jwtToken.Claims.Where(x => x.Type == "roles").Select(x => x.Value).ToList(),
                };

                context.Items.Add("userName", user.UserName);

                if(user.Roles.Count == 0)
                {
                    throw new AppException("User's role not found", ExceptionTypes.NotFound.GetValue());
                }

                var controllerName = context.Request.RouteValues.First(x => x.Key == "controller").Value;
                var actionName = context.Request.RouteValues.First(x => x.Key == "action").Value;
                var routePath = string.Format("/api/{0}/{1}", controllerName, actionName);
                var apiRoles = GetApiRoles();

                bool isAuthorized = apiRoles.Where(x => user.Roles.Contains(x.RoleName))
                                                .Any(x => x.ApiRoutePath == routePath);

                if (!isAuthorized)
                {
                    throw new AppException("Unauthorized user", ExceptionTypes.UnAuthorized.GetValue());
                }

            }
            catch (SecurityTokenExpiredException)
            {
                throw new AppException("Token is expired", ExceptionTypes.UnAuthorized.GetValue());
            }
            catch (SecurityTokenException)
            {
                throw new AppException("Invalid token", ExceptionTypes.UnAuthorized.GetValue());
            }
            catch (AppException e)
            {
                throw new AppException(e.Message, e.ExceptionType);
            }
        }

        private List<GetApiRoleResponse> GetApiRoles()
        {
            if (cache.TryGetValue(CacheTypes.ApiRoleCache.GetValue(), out List<GetApiRoleResponse> apiRoles))
            {
                return apiRoles;
            }
            apiRoles = new();
            var dbContext = Provider.Resolve<Context>();
            var allApiRoles = dbContext.Set<ApiRole>()
                                    .AsNoTracking()
                                    .Include(x => x.Api)
                                    .Include(x => x.Role)
                                    .ToList();

            foreach (var apiRole in allApiRoles)
            {
                apiRoles.Add(new GetApiRoleResponse()
                {
                    ApiId = apiRole.ApiId,
                    RoleId = apiRole.RoleId,
                    RoleName = apiRole.Role.RoleName,
                    ApiRoutePath = apiRole.Api.ApiRoute
                });
            }

            cache.Set(CacheTypes.ApiRoleCache.GetValue(), apiRoles);

            return apiRoles;
        }
    }

    public class UserInfoToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }

    }
}
