using Azure.Core;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Like;
using Recipe.Data.Repository.Implementation;
using Recipe.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Recipe.Data.Services
{
    public class LikeService(ILikeRepository _like)
    {
        public async Task<bool> AddLike(LikeDTO request)
        {
            var like = new Like()
            {
                UserID = request.UserID,
                RecipeID = request.RecipeID,
                IsLiked = request.IsLiked,
            };

            var response = await _like.AddLike(like);
            return response;
        }

        public async Task<LikeDTO> GetLike(Guid userID, Guid recipeID)
        {
            var like = await _like.GetLike(userID, recipeID);

            var response = new LikeDTO();

            if (like != null)
            {
                response.UserID = like.UserID;
                response.RecipeID = like.RecipeID;
                response.IsLiked = like.IsLiked;
            }

            return response;
        }

        public async Task<bool> RemoveLike(LikeDTO request)
        {
            var like = new Like()
            {
                UserID = request.UserID,
                RecipeID = request.RecipeID,
                IsLiked = request.IsLiked,
            };

            var response = await _like.RemoveLike(like);

            return response;
        }

        public async Task<IEnumerable<object>> GetLikes()
        {
            var likes = await _like.GetAllLikes(); // Retrieve all likes
            var listOfLikes = new List<LikeDTO>();

            // Map retrieved likes to LikeDTO
            if (likes != null)
            {
                foreach (var like in likes)
                {
                    var item = new LikeDTO()
                    {
                        UserID = like.UserID,
                        RecipeID = like.RecipeID,
                        IsLiked = like.IsLiked
                    };

                    listOfLikes.Add(item);
                }

                // Group by RecipeID and calculate counts
                var response = listOfLikes
                    .GroupBy(like => like.RecipeID) // Group by RecipeID
                    .Select(group => new
                    {
                        RecipeID = group.Key,        // Group key (RecipeID)
                        LikeCount = group.Count()    // Count of likes
                    });

                return response; // Return grouped result
            }

            // If no likes exist, return an empty result
            return Enumerable.Empty<object>();
        }


        public async Task<IEnumerable<LikeDTO>> GetAllLikes(Guid id)
        {
            var likes = await _like.GetAllLikes(id);
            var response = new List<LikeDTO>();

            if (likes != null)
            {
                foreach (var like in likes)
                {
                    var item = new LikeDTO()
                    {
                        UserID = like.UserID,
                        RecipeID = like.RecipeID,
                        IsLiked = like.IsLiked
                    };

                    response.Add(item);
                }
            }
            return response;
        }
    }
}
