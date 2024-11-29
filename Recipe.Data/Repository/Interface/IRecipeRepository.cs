using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<RecipeModel>> GetAllRecipes();
        Task<IEnumerable<RecipeModel>> GetByCategory(Guid categoryID);
        Task<IEnumerable<RecipeModel>> GetByHashtag(Guid hashtagID);
        Task<IEnumerable<RecipeModel>> GetByUser(Guid userID);
        Task<RecipeModel> GetRecipeById(Guid id);
        Task<bool> AddRecipe(RecipeModel recipe);
        Task<bool> UpdateRecipe(RecipeModel recipe);
        Task<bool> DeleteRecipe(Guid id);
    }
}
