using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsVerified { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        //Navigation Properties
        public ICollection<RecipeModel> Recipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
