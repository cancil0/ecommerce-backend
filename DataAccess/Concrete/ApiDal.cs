using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class ApiDal : GenericDal<Api>, IApiDal
    {
        public ApiDal(Context context) : base(context) {}
    }
}
