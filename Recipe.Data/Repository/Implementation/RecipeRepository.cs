using Microsoft.EntityFrameworkCore;
using Recipe.Data.Context;
using Recipe.Data.Models.Domains;
using Recipe.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Implementation
{
    public class RecipeRepository(ApplicationDbContext _context) : IRecipeRepository
    {
        public async Task<bool> AddRecipe(RecipeModel recipe)
        {
            try
            {
                await _context.Recipes.AddAsync(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteRecipe(Guid id)
        {
            try
            {
                var recipe = await _context.Recipes.FindAsync(id);
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IEnumerable<RecipeModel>> GetAllRecipes()
        {
            return await _context.Recipes.ToListAsync();
        }
        public async Task<IEnumerable<RecipeModel>> GetByCategory(Guid categoryID)
        {
            return await _context.Recipes.Where(x => x.CategoryID == categoryID).ToListAsync();
        }
        public async Task<IEnumerable<RecipeModel>> GetByHashtag(Guid hashtagID)
        {
            return await _context.Recipes.Where(x => x.Hashtags.Any(y => y.HashtagID == hashtagID)).ToListAsync();
        }
        public async Task<IEnumerable<RecipeModel>> GetByUser(Guid userID)
        {
            return await _context.Recipes.Where(x => x.UserID == userID).ToListAsync();
        }
        public async Task<RecipeModel> GetRecipeById(Guid id)
        {
            return await _context.Recipes.FindAsync(id);
        }
        public async Task<bool> UpdateRecipe(RecipeModel recipe)
        {
            try
            {
                _context.Recipes.Update(recipe);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
