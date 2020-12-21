using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.DAL.Entities;

namespace RestaurantService.BLL.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<IngredientDto, Ingredient>();
            
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}