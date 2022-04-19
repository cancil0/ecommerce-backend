using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfApiLogRepository : GenericDal<ApiLog>, IApiLogDal
    {
    }
}
