using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class UserRoleDal : GenericDal<UserRole>, IUserRoleDal
    {
        public UserRoleDal(Context context) : base(context) { }
    }
}
