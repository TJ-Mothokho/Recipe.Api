using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class Hashtag
    {
        [Key]
        public Guid HashtagID { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public ICollection<RecipeModel> Recipes { get; set; }
    }
}
