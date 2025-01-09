﻿using AutoMapper;
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

                var user = new User
                {
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    DateOfBirth = request.DateOfBirth,
                    Website = request.Website,
                    Bio = request.Bio,
                    ProfilePicture = new byte[request.ProfilePicture.Length],
                    IsVerified = false,
                    Role = "User",
                    CreatedAt = DateTime.Now,
                    Status = "Active"
                };

                using (var stream = new MemoryStream())
                {
                    request.ProfilePicture.CopyTo(stream);
                    user.ProfilePicture = stream.ToArray();
                }

                //var user = _mapper.Map<User>(request);
                //user.DateOfBirth = DateOnly.FromDayNumber(request.DateOfBirth);
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

            var response = new List<UserDetailsDTO>();

            foreach (var user in users)
            {
                var detail = new UserDetailsDTO
                {
                    UserID = user.UserID,
                    Username = user.Username,
                    Bio = user.Bio,
                    Website = user.Website,
                    Email = user.Email,
                    ProfilePicture = user.ProfilePicture,
                    IsVerified = user.IsVerified,
                    CreatedAt = user.CreatedAt
                };

                response.Add(detail);
            }

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

        public async Task<bool> UpdateUserAsync(UpdateUserDTO request)
        {
            try
            {
                // Create an instance of the PasswordHasher class
                PasswordHasher hasher = new PasswordHasher(request.Password);

                // Hash the password
                request.Password = hasher.GetPassword();
                request.Username = request.Username.ToLower();

                var user = new User
                {
                    UserID = request.UserID,
                    Username = request.Username,
                    Email = request.Email,
                    Password = request.Password,
                    Website = request.Website,
                    Bio = request.Bio,
                    ProfilePicture = new byte[request.ProfilePicture.Length]
                };

                using (var stream = new MemoryStream())
                {
                    request.ProfilePicture.CopyTo(stream);
                    user.ProfilePicture = stream.ToArray();
                }

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

        public async Task<ReadLoggedInDetailsDTO> Login(string username, string password)
        {
            // Create an instance of the PasswordHasher class
            PasswordHasher hasher = new PasswordHasher(password);

            // Hash the password
            password = hasher.GetPassword();
            username = username.ToLower();

            var user = await _userRepository.Login(username, password);

            var userDetails = new ReadLoggedInDetailsDTO();

            if (user != null)
            {
                userDetails.UserID = user.UserID;
                userDetails.Username = user.Username;
                userDetails.Email = user.Email;
                userDetails.Website = user.Website;
                userDetails.Bio = user.Bio;
                userDetails.Role = user.Role;
                userDetails.CreatedAt = user.CreatedAt;
                userDetails.ProfilePicture = user.ProfilePicture;
                userDetails.IsVerified = user.IsVerified;
            }

            return userDetails;
        }


    }
}
