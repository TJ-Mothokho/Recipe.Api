using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.User;
using Recipe.Data.Repository.Implementation;
using Recipe.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Services
{
    public class UserServices(IUserRepository _userRepository, IMapper _mapper)
    {
        public async Task<bool> AddUserAsync(RegisterUserDTO request)
        {
            try
            {
                // Create an instance of the PasswordHasher class
                PasswordHasher hasher = new PasswordHasher(request.Password);

                // Hash the password
                request.Password = hasher.GetPassword();
                request.Username = request.Username.ToLower();

                var user = _mapper.Map<User>(request);
                await _userRepository.AddAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            var doesExist = await _userRepository.GetByUsernameAsync(username);
            return doesExist;
        }
    }
}
