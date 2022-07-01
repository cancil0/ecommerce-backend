using DataAccess.Repository;
using Entities.Concrete;
using Entities.Dto.RequestDto.UserRequestDto;

namespace DataAccess.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
        User Get(GetUserRequest userRequest, bool throwException = true);
        Task<User> GetAsync(GetUserRequest userRequest, bool throwException, CancellationToken cancellationToken = default);
        User GetCreateUser(GetUserRequest userRequest, bool throwException = true);
    }
}
