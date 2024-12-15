using Azure.Core;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Like;
using Recipe.Data.Repository.Implementation;
using Recipe.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<int> GetLikes(Guid recipeID)
        {
            return await _like.GetLikeCount(recipeID);
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
