using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeDto, RecipeViewModel>();
            
            CreateMap<RecipeDto, DetailedRecipeViewModel>();

            CreateMap<DetailedRecipeViewModel, RecipeDto>();
        }
    }
}