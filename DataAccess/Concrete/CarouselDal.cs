using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using Infrastructure.Concrete;

namespace DataAccess.Concrete
{
    public class CarouselDal : GenericDal<Carousel>, ICarouselDal
    {
        public CarouselDal(Context context) : base(context) { }
    }
}
