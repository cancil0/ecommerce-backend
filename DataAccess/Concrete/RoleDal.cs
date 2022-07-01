using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class RoleDal : GenericDal<Role>, IRoleDal
    {
        public RoleDal(Context context) : base(context) { }
    }
}