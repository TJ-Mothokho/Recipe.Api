using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models.DTOs.Category;
using Recipe.Data.Services;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CategoryService _categoryService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategories();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var response = await _categoryService.GetCategotyById(id);
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory(CreateCategoryDTO request)
        {
            var response = await _categoryService.AddCategory(request);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateCategory(ReadCategoryDTO request)
        {
            var response = await _categoryService.UpdateCategory(request);
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return Ok(response);
        }
    }
}
