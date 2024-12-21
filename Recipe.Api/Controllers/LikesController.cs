using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models.DTOs.Like;
using Recipe.Data.Services;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController(LikeService _likeService) : ControllerBase
    {
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllLikes(Guid userID)
        {
            var Likes = await _likeService.GetAllLikes(userID);
            return Ok(Likes);
        }

        [HttpPost("/api/Like")]
        public async Task<IActionResult> AddLike(Guid userID, Guid recipeID)
        {
            var like = new LikeDTO()
            {
                UserID = userID,
                RecipeID = recipeID,
                IsLiked = true
            };

            var result = await _likeService.AddLike(like);

            return Ok(result);
        }

        [HttpPost("/api/RemoveLike")]
        public async Task<IActionResult> RemoveLike(Guid userID, Guid recipeID)
        {
            var like = new LikeDTO()
            {
                UserID = userID,
                RecipeID = recipeID,
                IsLiked = false
            };

            var result = await _likeService.RemoveLike(like);

            return Ok(result);
        }

        [HttpGet("GetLikeCount")]
        public async Task<IActionResult> GetLikeCount()
        {
            var likeCount = await _likeService.GetLikes();
            return Ok(likeCount);
        }
    }
}
