using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class CategoryDal : GenericDal<Category>, ICategoryDal
    {
        public CategoryDal(Context context) : base(context) { }
    }
}