using Core.ExceptionHandler;
using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Entities.Enums;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class CartDal : GenericDal<Cart>, ICartDal
    {
        public CartDal(Context context) : base(context) { }

        public Cart GetUserCart(Guid userId, bool throwException)
        {
            var cart = dbSet.FirstOrDefault(x => x.UserId == userId);
            if (cart == null && throwException)
                throw new AppException("Cart.UserCartNotFound", ExceptionTypes.NotFound.GetValue(), userId.ToString());

            return cart;
        }
    }
}