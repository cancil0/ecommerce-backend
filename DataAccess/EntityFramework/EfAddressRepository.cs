using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfAddressRepository : GenericDal<Address>, IAddressDal
    {
    }
}
