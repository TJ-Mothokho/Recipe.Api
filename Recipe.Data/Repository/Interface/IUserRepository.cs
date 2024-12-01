using Microsoft.EntityFrameworkCore;
using Recipe.Data.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User entity);
        

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetByIdAsync(Guid id);

        Task<IEnumerable<User>> SearchUsername(string username);

        Task<bool> GetByUsernameAsync(string username);

        Task<bool> UpdateAsync(User entity);

        Task<User> Login(string username, string password);
    }
}
