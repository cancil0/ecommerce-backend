using Entities.Concrete;
using Entities.Dto.RequestDto.CarouselRequestDto;

namespace Business.Abstract
{
    public interface ICarouselService
    {
        Carousel GetCarousel(Guid carouselId);
        List<Carousel> GetCarousels();
        void AddCarousel(AddCarouselRequest carouselRequest);
        void UpdateCarousel(Carousel carousel);
        void DeleteCarousel(Guid carouselId);
    }
}
