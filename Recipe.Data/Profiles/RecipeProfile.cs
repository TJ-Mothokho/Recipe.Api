using AutoMapper;
using Recipe.Data.Models.Domains;
using Recipe.Data.Models.DTOs.Recipe;

namespace Recipe.Data.Profiles
{
    public class RecipeProfile:Profile
    {
        public RecipeProfile()
        {
            CreateMap<CreateRecipeDTO, RecipeModel>()
                .ForMember(recipe => recipe.CreatedAt, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(recipe => recipe.Status, map => map.MapFrom(_ => "Active"))
                .ForMember(recipe => recipe.IsEdited, map => map.MapFrom(_ => false));

            CreateMap<UpdateRecipeDTO, RecipeModel>()
                .ForMember(recipe => recipe.IsEdited, map => map.MapFrom(_ => true));

            CreateMap<RecipeModel, RecipeDetailsDTO>();
        }
    }
}
