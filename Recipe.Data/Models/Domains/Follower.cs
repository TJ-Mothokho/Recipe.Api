using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class Follower
    {
        public Guid FollowerID { get; set; }
        
        
        [ForeignKey("User")]
        public Guid UserID { get; set; }

        public User User { get; set; }
    }
}
