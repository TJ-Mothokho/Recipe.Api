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
    public class FollowerRepository : IFollowerRepository
    {
        private ApplicationDbContext _context;
        public FollowerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddFollower(Follower follower)
        {
            try
            {
                await _context.Followers.AddAsync(follower);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteFollower(Follower follower)
        {
            try
            {
                _context.Followers.Remove(follower);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Follower>> GetFollowersByID(Guid id)
        {
            return await _context.Followers.Where(x => x.Equals(id)).ToListAsync();
        }

        public async Task<int> GetFollowersCountByID(Guid id)
        {
            return await _context.Followers.Where(x => x.Equals(id)).CountAsync();
        }
    }
}
