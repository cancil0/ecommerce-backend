using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICartDal : IGenericDal<Cart>
    {
        Cart GetUserCart(Guid userId, bool throwException = true);
    }
}
