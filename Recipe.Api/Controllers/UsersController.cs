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
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync(RegisterUserDTO request)
        {
            //check if username exists
            if (await _userServices.UserExistsAsync(request.Username))
            {
                return BadRequest("Username already exists");
            }

            bool response = await _userServices.AddUserAsync(request);
            return Ok();
        }
    }
}
