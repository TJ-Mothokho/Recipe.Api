using AutoMapper;
using Azure.Core;
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
        public async Task<IEnumerable<UserDetailsDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<UserDetailsDTO>>(users);
            return response;
        }

        public async Task<UserDetailsDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            var response = _mapper.Map<UserDetailsDTO>(user);
            return response;
        }

        public async Task<IEnumerable<UserDetailsDTO>> SearchUserAsync(string username)
        {
            var users = await _userRepository.SearchUsername(username);
            var response = _mapper.Map<IEnumerable<UserDetailsDTO>>(users);
            return response;
        }

        public async Task<bool> UpdateUserAsync(UserDetailsDTO request)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                var response = await _userRepository.UpdateAsync(user);
                return response;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                user.Status = "InActive";
                var response = await _userRepository.UpdateAsync(user);
                return response;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserDetailsDTO> Login(string username, string password)
        {
            // Create an instance of the PasswordHasher class
            PasswordHasher hasher = new PasswordHasher(password);

            // Hash the password
            password = hasher.GetPassword();
            username = username.ToLower();

            var user = await _userRepository.Login(username, password);

            var userDetails = new UserDetailsDTO()
            {
                UserID = user.UserID,
                Username = user.Username,
                Email = user.Email,
                Website = user.Website,
                Bio = user.Bio,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                ProfilePicture = user.ProfilePicture,
                IsVerified = user.IsVerified,
            };

            return userDetails;
        }


    }
}
