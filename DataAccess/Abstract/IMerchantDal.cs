using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMerchantDal : IGenericDal<Merchant>
    {
        Merchant GetMerchantById(Guid merchantId, bool throwException = true);
    }
}
