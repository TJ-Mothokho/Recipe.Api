using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.User
{
    public class ReadLoggedInDetailsDTO
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsVerified { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public string token { get; set; }
    }
}
