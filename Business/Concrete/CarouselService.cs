using AutoMapper;
using Business.Abstract;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.CarouselRequestDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class CarouselService : BaseService<Carousel>, ICarouselService
    {
        private readonly ICarouselDal carouselDal;
        private readonly IMapper mapper;
        public CarouselService()
        {
            carouselDal = Resolve<ICarouselDal>();
            mapper = Resolve<IMapper>();
        }

        public Carousel GetCarousel(Guid carouselId)
        {
            var carousel = carouselDal.GetById(carouselId);

            if(carousel == null)
            {
                throw new AppException("Carousel.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            return carousel;
        }

        public List<Carousel> GetCarousels()
        {
            return carouselDal.GetAll().OrderBy(x => x.ImageOrder).ToList();
        }

        public void AddCarousel(AddCarouselRequest carouselRequest)
        {
            var carousel = mapper.Map<Carousel>(carouselRequest);
            carouselDal.Insert(carousel);
        }

        public void UpdateCarousel(Carousel carousel)
        {
            carouselDal.Update(carousel);
        }

        public void DeleteCarousel(Guid carouselId)
        {
            var carousel = carouselDal.GetById(carouselId);

            if (carousel == null)
            {
                throw new AppException("Carousel.NotFound", ExceptionTypes.NotFound.GetValue());
            }

            carouselDal.Delete(carousel);
        }
    }
}
