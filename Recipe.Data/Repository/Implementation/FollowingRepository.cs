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
    public class FollowingRepository : IFollowingRepository
    {
        private ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddFollowing(Following following)
        {
            try
            {
                await _context.Followings.AddAsync(following);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteFollowing(Following following)
        {
            try
            {
                _context.Followings.Remove(following);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Following>> GetFollowingsByID(Guid id)
        {
            return await _context.Followings.Where(x => x.FollowingID == id).ToListAsync();
        }

        public async Task<int> GetFollowingsCountByID(Guid id)
        {
            return await _context.Followings.Where(x => x.FollowingID == id).CountAsync();
        }
    }
}
