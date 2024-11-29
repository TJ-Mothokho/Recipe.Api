using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Profiles
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<AddLikeDTO, Like>()
                .ForMember(like => like.IsLiked, map => map.MapFrom(_ => true));

            CreateMap<RemoveLikeDTO, Like>()
                .ForMember(like => like.IsLiked, map => map.MapFrom(_ => false));
        }
    }
}
