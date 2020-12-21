using System.Collections.Generic;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<IEnumerable<DishDto>, IEnumerable<CategoryViewModel>>()
                .ConvertUsing<CategoryViewModelConverter>();

            CreateMap<RecipeDto, DetailedRecipeViewModel>();
        }
    }
}