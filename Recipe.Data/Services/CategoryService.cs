using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Category;
using Recipe.Data.Repository.Interface;
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
                var category = _mapper.Map<Category>(request);
                var response = await _category.AddCategory(category);
                return response;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ReadCategoryDTO>> GetAllCategories()
        {
            var categories = await _category.GetAllCategories();
            var response = _mapper.Map<IEnumerable<ReadCategoryDTO>>(categories);
            return response;
        }

        public async Task<ReadCategoryDTO> GetCategotyById(Guid id)
        {
            var category = await _category.GetCategoryById(id);
            var response = _mapper.Map<ReadCategoryDTO>(category);
            return response;
        }

        public async Task<bool> UpdateCategory(ReadCategoryDTO request)
        {
            try
            {
                var category = _mapper.Map<Category>(request);
                var response = await _category.UpdateCategory(category);
                return response;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteCategory(Guid id)
        {
            try
            {
                var response = await _category.DeleteCategory(id);
                return response;
            }
            catch
            {
                return false;
            }
        }
    }
}
