using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.DAL.Entities;

namespace RestaurantService.BLL.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>()
                .ForMember(
                    d => d.Ingredients,
                    opt 
                        => opt.MapFrom(s 
                            => s.Ingredients.Select(p => p.Name)));

            CreateMap<RecipeDto, Recipe>()
                .ForMember(d => d.Ingredients,
                    opt 
                        => opt.Ignore());
        }
    }
}