using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.User
{
    public class UpdateUserDTO
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
