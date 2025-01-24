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
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<bool> AddFollowing(Following following)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFollowing(Following following)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Following>> GetFollowingsByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetFollowingsCountByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
