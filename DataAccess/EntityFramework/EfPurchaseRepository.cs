using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfPurchaseRepository : GenericDal<Purchase>, IPurchaseDal
    {
    }
}
