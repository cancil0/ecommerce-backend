using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class ProductDetailDal : GenericDal<ProductDetail>, IProductDetailDal
    {
        public ProductDetailDal(Context context) : base(context) { }
    }
}