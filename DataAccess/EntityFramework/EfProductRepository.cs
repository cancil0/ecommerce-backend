using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfProductRepository : GenericDal<Product>, IProductDal
    {
    }
}
