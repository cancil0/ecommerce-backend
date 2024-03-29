﻿using Business.Abstract;
using Core.Attributes;
using Entities.Dto.RequestDto.CategoryRequestDto;
using Entities.Dto.ResponseDto.CategoryResponseDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_backend.Controllers.EntityController
{
    [Route("api/[controller]")]
    [ApiController]
    [Logger]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        /// <summary>
        /// Gets Category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("GetCategory")]
        public ActionResult<GetCategoryResponse> GetCategory([FromQuery] Guid categoryId)
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
        public ActionResult<List<GetCategoryResponse>> GetCategories()
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
        public ActionResult<List<GetCategoryResponse>> GetSubCategories([FromQuery] Guid categoryId)
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
