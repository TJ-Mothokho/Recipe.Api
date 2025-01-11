using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Recipe
{
    public class RecipeDetailsDTO
    {
        public Guid RecipeID { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Image { get; set; }
        public Guid CategoryID { get; set; }
        public string Category { get; set; }
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsEdited { get; set; }
        public List<string>? Hashtags { get; set; }
    }
}
