using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Services
{
    public class CategoryService(ICategoryRepository _category, IMapper _mapper)
    {
        public async Task<bool> AddCategory(CreateCategoryDTO request)
        {
            try
            {
                var category = _mapper.
                var response = _category.AddAsync(category);
                return response;
            }
            catch{return false;}
        }

        public async Task<IEnumerable<ReadCategoryDTO>> GetAllCategories()
        {
            
        }
    }
}
