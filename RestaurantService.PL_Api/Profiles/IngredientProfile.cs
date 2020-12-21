using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<IngredientDto, IngredientViewModel>();

            CreateMap<IngredientViewModel, IngredientDto>();
        }
    }
}