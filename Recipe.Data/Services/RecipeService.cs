using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Recipe;
using Recipe.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Services
{
    public class RecipeService(IRecipeRepository _recipeRepository, CategoryService _category, UserServices _user, IMapper _mapper)
    {
        public async Task<bool> AddRecipeAsync(CreateRecipeDTO request)
        {
            try
            {
                var recipe = new RecipeModel
                {
                    Title = request.Title,
                    Instructions = request.Instructions,
                    Image = new byte[request.Image.Length],
                    UserID = request.UserID,
                    CategoryID = request.CategoryID,
                    CreatedAt = DateTime.Now,
                    Status = "Active",
                    IsEdited = false

                    //Hashtags = request.Hashtags.Select(x => new Hashtag { Name = x }).ToList()
                };

                using (var stream = new MemoryStream())
                {
                    request.Image.CopyTo(stream);
                    recipe.Image = stream.ToArray();
                }


                await _recipeRepository.AddRecipe(recipe);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteRecipeAsync(Guid id)
        {
            try
            {
                await _recipeRepository.DeleteRecipe(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<RecipeDetailsDTO>> GetAllRecipesAsync()
        {
            var recipes = await _recipeRepository.GetAllRecipes();
            var users = await _user.GetAllUsersAsync();
            var categories = await _category.GetAllCategories();

            var response = new List<RecipeDetailsDTO>();

            foreach (var recipe in recipes)
            {
                var detail = new RecipeDetailsDTO
                {
                    RecipeID = recipe.RecipeID,
                    Title = recipe.Title,
                    Instructions = recipe.Instructions,
                    Image = $"data:image/jpg;base64, {Convert.ToBase64String(recipe.Image)}",
                    CategoryID= recipe.CategoryID,
                    UserID = recipe.UserID,
                    CreatedAt = recipe.CreatedAt,
                    IsEdited = recipe.IsEdited
                };

                var person = (from user in users
                              where detail.UserID == user.UserID
                              select user).FirstOrDefault();

                if(person != null)
                {
                    detail.UserName = person.Username;
                    detail.ProfilePicture = person.ProfilePicture;
                }

                var category = (from cat in categories
                               where detail.CategoryID == cat.CategoryID
                               select cat).FirstOrDefault();

                if(category != null)
                {
                    detail.Category = category.Name;
                }

                response.Add(detail);

            }

            return response;
        }

        public async Task<IEnumerable<RecipeDetailsDTO>> GetByCategoryAsync(Guid categoryID)
        {
            var recipes = await _recipeRepository.GetByCategory(categoryID);
            var map = _mapper.Map<IEnumerable<RecipeDetailsDTO>>(recipes);

            var response = await AddRecipeDetails(map);
            return response;
        }

        public async Task<IEnumerable<RecipeDetailsDTO>> GetByHashtagAsync(Guid hashtagID)
        {
            var recipes = await _recipeRepository.GetByHashtag(hashtagID);
            var map = _mapper.Map<IEnumerable<RecipeDetailsDTO>>(recipes);

            var response = await AddRecipeDetails(map);
            return response;
        }

        public async Task<IEnumerable<RecipeDetailsDTO>> GetByUserAsync(Guid userID)
        {
            var recipes = await _recipeRepository.GetByUser(userID);
            var map = _mapper.Map<IEnumerable<RecipeDetailsDTO>>(recipes);

            var response = await AddRecipeDetails(map);
            return response;
        }

        public async Task<RecipeDetailsDTO> GetRecipeByIdAsync(Guid id)
        {
            var recipe = await _recipeRepository.GetRecipeById(id);
            var map = _mapper.Map<RecipeDetailsDTO>(recipe);

            var response = await AddRecipeDetails(map);

            return response;
        }

        public async Task<bool> UpdateRecipeAsync(UpdateRecipeDTO request)
        {
            try
            {
                //var recipe = _mapper.Map<RecipeModel>(request);
                var recipe = new RecipeModel
                {
                    
                    RecipeID = request.RecipeID,
                    Title = request.Title,
                    Instructions = request.Instructions,
                    Image = new byte[request.Image.Length],
                    CategoryID = request.CategoryID,
                    IsEdited = true

                    //Hashtags = request.Hashtags.Select(x => new Hashtag { Name = x }).ToList()
                };

                using (var stream = new MemoryStream())
                {
                    request.Image.CopyTo(stream);
                    recipe.Image = stream.ToArray();
                }

                await _recipeRepository.UpdateRecipe(recipe);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<IEnumerable<RecipeDetailsDTO>> AddRecipeDetails(IEnumerable<RecipeDetailsDTO> recipes)
        {
            foreach (var item in recipes)
            {
                var category = await _category.GetCategotyById(item.CategoryID);
                item.Category = category.Name;

                var user = await _user.GetUserByIdAsync(item.UserID);
                item.UserName = user.Username;
            }
            return recipes;
        }

        private async Task<RecipeDetailsDTO> AddRecipeDetails(RecipeDetailsDTO recipes)
        {
            var category = await _category.GetCategotyById(recipes.CategoryID);
            recipes.Category = category.Name;

            var user = await _user.GetUserByIdAsync(recipes.UserID);
            recipes.UserName = user.Username;

            return recipes;
        }

    }
}
