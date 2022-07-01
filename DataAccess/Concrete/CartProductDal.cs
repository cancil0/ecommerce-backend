using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class CartProductDal : GenericDal<CartProduct>, ICartProductDal
    {
        public CartProductDal(Context context) : base(context) { }
    }
}

