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
    public class UserServices(IRepository<User> _userRepository, IMapper _mapper)
    {
        public async Task AddUserAsync(RegisterUserDTO request)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.AddAsync(user);
        }
    }
}
