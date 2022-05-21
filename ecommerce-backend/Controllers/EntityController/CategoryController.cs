using Business.Abstract;
using Core.Base.Concrete;
using Entities.Dto.RequestDto.CategoryRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        public CategoryController()
        {
            categoryService = Resolve<ICategoryService>();
        }

        /// <summary>
        /// Gets Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCategory")]
        public ActionResult GetCategory([FromQuery] Guid categoryId)
        {
            return Ok(categoryService.GetCategory(categoryId));
        }

        /// <summary>
        /// Gets All Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCategories")]
        public ActionResult GetCategories()
        {
            return Ok(categoryService.GetCategories());
        }

        /// <summary>
        /// Get Sub Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetSubCategories")]
        public ActionResult GetSubCategories([FromQuery] Guid categoryId)
        {
            return Ok(categoryService.GetSubCategories(categoryId));
        }

        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="addCategory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCategory")]
        public ActionResult AddCategory([FromBody] AddCategoryRequest addCategory)
        {
            categoryService.AddCategory(addCategory);
            return Ok();
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="categoryUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCategory")]
        public ActionResult UpdateCategory([FromBody] UpdateCategoryRequest categoryUpdate)
        {
            categoryService.UpdateCategory(categoryUpdate);
            return Ok();
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="deleteCategory"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCategory")]
        public ActionResult DeleteCategory([FromBody] DeleteCategoryRequest deleteCategory)
        {
            categoryService.DeleteCategory(deleteCategory);
            return Ok();
        }
    }
}
