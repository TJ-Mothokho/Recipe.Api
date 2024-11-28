using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("User")]
        public Guid UserID { get; set; }
        [ForeignKey("Recipe")]
        public Guid RecipeID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        //Navigation Properties
        public User User { get; set; }
        public Recipe Recipe { get; set; }
    }
}
