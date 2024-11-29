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
    public class CommentRepository(ApplicationDbContext _context):ICommentRepository
    {
        public async Task<bool> AddComment(Comment comment)
        {
            try
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IEnumerable<Comment>> GetCommentsByRecipe(Guid recipeID)
        {
            return await _context.Comments.Where(c => c.RecipeID == recipeID).ToListAsync();
        }
        public async Task<IEnumerable<Comment>> GetCommentsByUser(Guid userID)
        {
            return await _context.Comments.Where(x => x.UserID == userID).ToListAsync();
        }
        public async Task<int> GetCommentsCount(Guid recipeID)
        {
            return await _context.Comments.Where(x => x.RecipeID == recipeID).CountAsync(); ;
        }
        public async Task<bool> RemoveComment(Comment comment)
        {
            try
            {
                _context.Comments.Remove(comment);
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
