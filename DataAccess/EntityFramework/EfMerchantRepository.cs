using Core.Middleware.ExceptionMiddleware;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Enums;

namespace DataAccess.EntityFramework
{
    public class EfMerchantRepository : GenericDal<Merchant>, IMerchantDal
    {
        public Merchant GetMerchantById(Guid merchantId, bool throwException)
        {
            var merchant = Get(x => x.MerchantId == merchantId, x => x.Address, x => x.ProductDetails);
            if (throwException && merchant == null)
            {
                throw new AppException("Merchant.NotFound", ExceptionTypes.NotFound.GetValue());
            }
            return merchant;
        }
    }
}
