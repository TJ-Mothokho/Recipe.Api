using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Category")]
        public Guid CategoryID { get; set; }
        [ForeignKey("User")]
        public Guid UserID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }

        //Navigation Properties
        public Category Category { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Hashtag> Hashtags { get; set; }

    }
}
