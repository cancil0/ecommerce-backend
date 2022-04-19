using Entities.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Jwt
{
    public interface ITokenHelper
    {
        string GenerateToken(User user, IConfiguration configuration);

        bool IsTokenValid(string key, string token);

    }
}
