using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.Domains
{
    public class Following
    {
        public Guid FollowingID { get; set; }
        
        
        
        [ForeignKey("User")]
        public Guid UserID { get; set; }

        public User User { get; set; }
    }
}
