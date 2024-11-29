using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Data.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDTO, Category>()
                .ForMember(category => category.Status, map => map.MapFrom(_ => "Active"));

            CreateMap<UpdateCategoryDTO, Category>()
                .ForMember(category => category.Status, map => map.MapFrom(_ => "InActive"));

            CreateMap<Category, ReadCategoryDTO>();
        }
    }
}
