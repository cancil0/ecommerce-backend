using Core.ExceptionHandler;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Enums;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class MerchantDal : GenericDal<Merchant>, IMerchantDal
    {
        public MerchantDal(Context context) : base(context) { }

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