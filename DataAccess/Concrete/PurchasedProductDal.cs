using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class PurchasedProductDal : GenericDal<PurchasedProduct>, IPurchasedProductDal
    {
        public PurchasedProductDal(Context context) : base(context) { }
    }
}