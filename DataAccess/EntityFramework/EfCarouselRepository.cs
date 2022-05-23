using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfCarouselRepository : GenericDal<Carousel>, ICarouselDal
    {
    }
}
