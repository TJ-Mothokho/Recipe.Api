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
    public class FollowerRepository : IFollowerRepository
    {
        private ApplicationDbContext _context;
        public FollowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddFollower(Follower follower)
        {
            try
            {

            }
            catch
            {

            }

            throw new NotImplementedException();
        }

        public Task<bool> DeleteFollower(Follower follower)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Follower>> GetFollowersByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetFollowersCountByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
