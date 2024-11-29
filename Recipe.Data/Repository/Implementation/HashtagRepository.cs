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
    public class HashtagRepository(ApplicationDbContext _context) : IHashtagRepository
    {
        public async Task<bool> AddHashtag(Hashtag hashtag)
        {
            try
            {
                await _context.Hashtags.AddAsync(hashtag);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<IEnumerable<Hashtag>> GetAllHashtags()
        {
            return await _context.Hashtags.ToListAsync();
        }
        public async Task<Hashtag> GetHashtagById(Guid id)
        {
            return await _context.Hashtags.FindAsync(id);
        }
    }
}
