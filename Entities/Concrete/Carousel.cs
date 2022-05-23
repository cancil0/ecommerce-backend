using Entities.Abstract;

namespace Entities.Concrete
{
    public class Carousel : DeleteEntity
    {
        public Guid CarouselId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int ImageOrder { get; set; }
        public string LinkToNavigate { get; set; }
    }
}
