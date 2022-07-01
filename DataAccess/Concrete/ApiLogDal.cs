using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class ApiLogDal : GenericDal<ApiLog>, IApiLogDal
    {
        public ApiLogDal(Context context) : base(context) {}
    }
}
