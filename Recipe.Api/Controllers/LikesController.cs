using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
