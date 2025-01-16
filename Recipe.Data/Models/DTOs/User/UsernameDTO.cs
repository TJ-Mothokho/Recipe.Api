using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.User
{
    public class UsernameDTO
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
    }
}
