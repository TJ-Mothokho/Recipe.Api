using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class Like
    {
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        [ForeignKey("Recipe")]
        public Guid RecipeID { get; set; }
        public bool IsLiked { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public RecipeModel Recipe { get; set; }
    }
}
