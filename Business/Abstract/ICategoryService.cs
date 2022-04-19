using Entities.Dto.RequestDto.CategoryRequestDto;
using Entities.Dto.ResponseDto.CategoryResponseDto;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<GetCategoryResponse> GetCategories();
        List<GetCategoryResponse> GetSubCategories(Guid categoryId);
        void AddCategory(AddCategoryRequest addCategory);
        void DeleteCategory(DeleteCategoryRequest deleteCategory);

        void UpdateCategory(UpdateCategoryRequest updateCategory);
    }
}
