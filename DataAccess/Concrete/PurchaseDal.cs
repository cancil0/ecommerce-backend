using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class PurchaseDal : GenericDal<Purchase>, IPurchaseDal
    {
        public PurchaseDal(Context context) : base(context) { }
    }
}