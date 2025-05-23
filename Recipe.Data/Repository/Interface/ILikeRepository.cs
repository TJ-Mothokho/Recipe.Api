﻿using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface ILikeRepository
    {
        Task<bool> AddLike(Like like);
        Task<bool> RemoveLike(Like like);
        Task<Like> GetLike(Guid userID, Guid recipeID);
        Task<IEnumerable<Like>> GetAllLikes(Guid userID);
        Task<IEnumerable<Like>> GetAllLikes();
    }
}
