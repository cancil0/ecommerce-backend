namespace Entities.Dto.RequestDto.CategoryRequestDto
{
    public class DeleteCategoryRequest
    {
        public Guid? CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
