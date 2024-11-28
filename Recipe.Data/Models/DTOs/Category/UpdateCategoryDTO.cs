using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Models.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
