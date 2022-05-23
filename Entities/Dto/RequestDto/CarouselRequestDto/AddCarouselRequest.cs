namespace Entities.Dto.RequestDto.CarouselRequestDto
{
    public class AddCarouselRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int ImageOrder { get; set; }
        public string LinkToNavigate { get; set; }
    }
}
