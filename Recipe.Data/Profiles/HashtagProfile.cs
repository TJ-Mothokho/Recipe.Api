using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Hashtag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Profiles
{
    public class HashtagProfile : Profile
    {
        public HashtagProfile()
        {
            CreateMap<CreateHashtagDTO, Hashtag>();
            CreateMap<Hashtag, ReadHashtagDTO>();
        }
    }
}
