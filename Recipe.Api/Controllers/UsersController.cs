using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Followers;
using Recipe.Data.Models.DTOs.User;
using Recipe.Data.Services;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserServices _userServices, FollowerServices _followerServices, FollowingServices _followingServices) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserDTO request)
        {
            //check if username exists
            if (await _userServices.UserExistsAsync(request.Username))
            {
                return Ok("Username already exists");
            }
            bool response = await _userServices.AddUserAsync(request);
            return Ok();
        }

        [HttpPost("Follow")]
        public async Task<IActionResult> AddFollow(FollowerDTO follow)
        {
            var follower = new FollowerDTO()
            {
                FollowerID = follow.UserID,
                UserID = follow.FollowerID,
            };
            
            var followerResponse = await _followerServices.AddFollower(follower);

            var following = new FollowingDTO()
            {
                FollowingID = follow.FollowerID,
                UserID = follow.UserID
            };

            var followingResponse = await _followingServices.AddFollowing(following);

            if(!followerResponse || !followingResponse)
            {
                if(!followingResponse && !followerResponse)
                {
                    return BadRequest("Couldn't add both follower and following");
                }
                else if(followerResponse)
                {
                    return BadRequest("Couldn't add following");
                }
                else
                {
                    return BadRequest("Couldn't add follower");
                }
            }
            else
            {
                return Ok("Followed!");
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var response = await _userServices.GetAllUsersAsync();
            return Ok(response);
        }

        [HttpGet("GetUsernames")]
        public async Task<IActionResult> GetAllUsernames()
        {
            var response = await _userServices.GetUsernames();
            return Ok(response);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var response = await _userServices.GetUserByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchUserAsync(string username)
        {
            var response = await _userServices.SearchUserAsync(username);
            return Ok(response);
        }

        [HttpGet("Followers")]
        public async Task<IActionResult> GetFollowers(Guid userID)
        {
            var response = await _followerServices.GetFollowersByID(userID);
            return Ok(response);
        }

        [HttpGet("FollowersCount")]
        public async Task<IActionResult> GetFollowersCount(Guid userID)
        {
            var response = await _followerServices.GetFollowersCountByID(userID);
            return Ok(response);
        }

        [HttpGet("Followings")]
        public async Task<IActionResult> GetFollowings(Guid userID)
        {
            var response = await _followingServices.GetFollowingsByID(userID);
            return Ok(response);
        }

        [HttpGet("FollowingsCount")]
        public async Task<IActionResult> GetFollowingsCount(Guid userID)
        {
            var response = await _followingServices.GetFollowingsCountByID(userID);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserDTO request)
        {
            bool response = await _userServices.UpdateUserAsync(request);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            bool response = await _userServices.DeleteUserAsync(id);
            return Ok();
        }

        [HttpDelete("Unfollow")]
        public async Task<IActionResult> DeleteFollow(FollowerDTO follow)
        {
            var followerResponse = await _followerServices.DeleteFollower(follow);

            var following = new FollowingDTO()
            {
                FollowingID = follow.UserID,
                UserID = follow.FollowerID
            };

            var followingResponse = await _followingServices.DeleteFollowing(following);

            if (!followerResponse || !followingResponse)
            {
                if (!followingResponse && !followerResponse)
                {
                    return BadRequest("Couldn't remove both follower and following");
                }
                else if (followerResponse)
                {
                    return BadRequest("Couldn't remove following");
                }
                else
                {
                    return BadRequest("Couldn't remove follower");
                }
            }
            else
            {
                return Ok("Unfollowed!");
            }
        }


    }
}
