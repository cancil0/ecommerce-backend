using Entities.Concrete;

namespace Core.Abstract
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user, CancellationToken cancellationToken = default);
        Task<bool> IsTokenValid(string token, CancellationToken cancellationToken = default);
    }
}
