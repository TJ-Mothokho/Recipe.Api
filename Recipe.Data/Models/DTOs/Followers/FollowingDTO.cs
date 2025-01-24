using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Followers
{
    public class FollowingDTO
    {
        public Guid FollowingID { get; set; }
        public Guid UserID { get; set; }
    }
}
