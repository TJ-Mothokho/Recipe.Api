using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models.DTOs.Like;
using Recipe.Data.Models.DTOs.Recipe;
using Recipe.Data.Services;
using System.Linq.Expressions;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController(RecipeService _recipeService, LikeService _likeService) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }
        [HttpGet("/Get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            return Ok(recipe);
        }
        [HttpGet("category/{categoryID}")]
        public async Task<IActionResult> GetByCategoryAsync(Guid categoryID)
        {
            var recipes = await _recipeService.GetByCategoryAsync(categoryID);
            return Ok(recipes);
        }
        [HttpGet("hashtag/{hashtagID}")]
        public async Task<IActionResult> GetByHashtagAsync(Guid hashtagID)
        {
            var recipes = await _recipeService.GetByHashtagAsync(hashtagID);
            return Ok(recipes);
        }
        [HttpGet("user/{userID}")]
        public async Task<IActionResult> GetByUserAsync(Guid userID)
        {
            var recipes = await _recipeService.GetByUserAsync(userID);
            return Ok(recipes);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddRecipeAsync(CreateRecipeDTO request)
        {
            var result = await _recipeService.AddRecipeAsync(request);
            return Ok(result);
        }

        [HttpPut("/Update/{id}")]
        public async Task<IActionResult> UpdateRecipeAsync(UpdateRecipeDTO request)
        {
            var result = await _recipeService.UpdateRecipeAsync(request);
            return Ok(result);
        }

        [HttpDelete("/Delete/{id}")]
        public async Task<IActionResult> DeleteRecipeAsync(Guid id)
        {
            var result = await _recipeService.DeleteRecipeAsync(id);
            return Ok(result);
        }

      


    }
}
