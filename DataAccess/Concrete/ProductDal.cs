using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class ProductDal : GenericDal<Product>, IProductDal
    {
        public ProductDal(Context context) : base(context) { }
    }
}