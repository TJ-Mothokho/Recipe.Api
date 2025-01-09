using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.User;
using Recipe.Data.Services;

namespace Recipe.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserServices _userServices) : ControllerBase
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var response = await _userServices.GetAllUsersAsync();
            return Ok(response);
        }

        [HttpGet("GetById")]
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

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserAsync(UpdateUserDTO request)
        {
            bool response = await _userServices.UpdateUserAsync(request);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            bool response = await _userServices.DeleteUserAsync(id);
            return Ok();
        }
    }
}
