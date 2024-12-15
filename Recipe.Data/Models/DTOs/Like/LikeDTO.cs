using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Like
{
    public class LikeDTO
    {
        public Guid UserID { get; set; }
        public Guid RecipeID { get; set; }
        public bool IsLiked { get; set; }
    }
}
