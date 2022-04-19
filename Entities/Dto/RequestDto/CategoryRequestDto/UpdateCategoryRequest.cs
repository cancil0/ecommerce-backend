namespace Entities.Dto.RequestDto.CategoryRequestDto
{
    public class UpdateCategoryRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
