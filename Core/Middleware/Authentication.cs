using Core.ExceptionHandler;
using Core.IoC;
using Entities.Concrete;
using Entities.Dto.ResponseDto.ApiRoleResponse;
using Entities.Enums;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Core.Middleware
{
    public class Authentication : IMiddleware
    {
        private readonly IMemoryCache cache;
        private readonly IConfiguration configuration;
        private readonly Context context;

        public Authentication(IMemoryCache cache, IConfiguration configuration, Context context)
        {
            this.cache = cache;
            this.configuration = configuration;
            this.context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var isAllowAnonymousController = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();

            if (isAllowAnonymousController == null)
            {
                CheckToken(context);
            }

            await next(context);
        }

        private void CheckToken(HttpContext context)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault();
                if (string.IsNullOrEmpty(token))
                {
                    throw new AppException("Jwt.TokenNotFound", ExceptionTypes.NotFound.GetValue());
                }
                token = token.Split(" ").Last();
                context.Request.Headers.Authorization = string.Format("Bearer {0}", token);
                var tokenHandler = new JwtSecurityTokenHandler();
                var secretToken = configuration.GetValue<string>("JwtSettings:Secret");
                var key = Encoding.ASCII.GetBytes(secretToken);
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

                context.Items.Add("UserName", user.UserName);

                if (user.Roles.Count == 0)
                {
                    throw new AppException("User.RoleNotFound", ExceptionTypes.NotFound.GetValue());
                }

                var controllerName = context.Request.RouteValues.First(x => x.Key == "controller").Value;
                var actionName = context.Request.RouteValues.First(x => x.Key == "action").Value;
                var routePath = string.Format("/api/{0}/{1}", controllerName, actionName);
                var apiRoles = GetApiRoles();

                bool isAuthorized = apiRoles.Where(x => user.Roles.Contains(x.RoleName))
                                                .Any(x => x.ApiRoutePath == routePath);

                if (!isAuthorized)
                {
                    throw new AppException("User.Unauthorized", ExceptionTypes.UnAuthorized.GetValue());
                }

            }
            catch (SecurityTokenExpiredException)
            {
                throw new AppException("Jwt.ExpiredToken", ExceptionTypes.UnAuthorized.GetValue());
            }
            catch (SecurityTokenException)
            {
                throw new AppException("Jwt.InvalidToken", ExceptionTypes.UnAuthorized.GetValue());
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
            var allApiRoles = context.Set<ApiRole>()
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
