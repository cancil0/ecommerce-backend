using Core.ExceptionHandler;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Enums;

namespace DataAccess.EntityFramework
{
    public class EfCartRepository : GenericDal<Cart>, ICartDal
    {
        public Cart GetUserCart(Guid userId, bool throwException)
        {
            var cart = dbSet.FirstOrDefault(x => x.UserId == userId);
            if (cart == null && throwException)
                throw new AppException("Cart.UserCartNotFound", ExceptionTypes.NotFound.GetValue(), userId.ToString());

            return cart;
        }

    }
}
