using Core.ExceptionHandler;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Enums;
using Infrastructure.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class MerchantDal : GenericDal<Merchant>, IMerchantDal
    {
        public MerchantDal(Context context) : base(context) { }

        public Merchant GetMerchantById(Guid merchantId, bool throwException)
        {
            var merchant = Get(x => x.MerchantId == merchantId, x => x.Include(x => x.Address).Include(x => x.ProductDetails));
            if (throwException && merchant == null)
            {
                throw new AppException("Merchant.NotFound", ExceptionTypes.NotFound.GetValue());
            }
            return merchant;
        }
    }
}