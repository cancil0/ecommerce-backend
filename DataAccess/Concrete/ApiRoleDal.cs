using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class ApiRoleDal : GenericDal<ApiRole>, IApiRoleDal
    {
        public ApiRoleDal(Context context) : base(context) {}
    }
}
