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
    public class LikeRepository(ApplicationDbContext _context) : ILikeRepository
    {
        public async Task<bool> AddLike(Like like)
        {
            try
            {
                await _context.Likes.AddAsync(like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RemoveLike(Like like)
        {
            try
            {
                _context.Likes.Remove(like);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Like> GetLike(Guid userID, Guid recipeID)
        {
            return await _context.Likes.FirstOrDefaultAsync(x => x.UserID == userID && x.RecipeID == recipeID);
        }

        public async Task<IEnumerable<Like>> GetAllLikes(Guid userID)
        {
            return await _context.Likes.Where(x => x.UserID == userID).ToListAsync();
        }

        public async Task<IEnumerable<Like>> GetAllLikes()
        {
            return await _context.Likes.ToListAsync();
        }


    }
}
