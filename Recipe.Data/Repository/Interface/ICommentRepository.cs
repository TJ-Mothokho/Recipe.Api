using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface ICommentRepository
    {
        Task<bool> AddComment(Comment comment);
        Task<bool> RemoveComment(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsByRecipe(Guid recipeID);
        Task<IEnumerable<Comment>> GetCommentsByUser(Guid userID);
        Task<int> GetCommentsCount(Guid recipeID);
    }
}
