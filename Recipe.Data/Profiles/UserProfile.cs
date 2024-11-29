using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDTO, User>()
                .ForMember(user => user.CreatedAt, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(user => user.Status, map => map.MapFrom(_ => "Active"))
                .ForMember(user => user.Role, map => map.MapFrom(_ => "User"));

            CreateMap<UpdateUserDTO, User>();

            CreateMap<User, UserDetailsDTO>();
        }
    }
}
