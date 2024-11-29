using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Comment
{
    public class ReadCommentDTO
    {
        public Guid CommentID { get; set; }
        public string UserName { get; set; }
        public Guid UserID { get; set; }
        public Guid RecipeID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
