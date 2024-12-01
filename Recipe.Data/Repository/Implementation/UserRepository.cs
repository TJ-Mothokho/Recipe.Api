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
    public class UserRepository(ApplicationDbContext _context) : IUserRepository
    {
        public async Task<bool> AddAsync(User entity)
        {
            try
            {
                await _context.People.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.People.Where(x => x.Status == "Active").ToListAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<IEnumerable<User>> SearchUsername(string username)
        {
            //get all users whose username contains the search term
            return await _context.People.Where(x => x.Username.Contains(username)).ToListAsync();
        }

        public async Task<bool> GetByUsernameAsync(string username)
        {
            var result = await _context.People.AnyAsync(x => x.Username == username);
            return result;
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            try
            {
                _context.People.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.People.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                 user = await _context.People.FirstOrDefaultAsync(u => u.Email == username && u.Password == password);
            }

            return user;
        }
    }
}
