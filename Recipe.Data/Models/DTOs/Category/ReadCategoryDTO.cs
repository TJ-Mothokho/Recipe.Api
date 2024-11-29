using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Category
{
    public class ReadCategoryDTO
    {
        public Guid CategoryID { get; set; }
        public string Name { get; set; }
    }
}
