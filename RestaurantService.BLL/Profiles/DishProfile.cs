using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.DAL.Entities;

namespace RestaurantService.BLL.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Recipe, DishDto>()
                .ForMember(
                    dto => dto.Weights,
                    opt => opt
                        .MapFrom(obj => obj
                            .Dishes.Select(p => p.Weight)))
                .ForMember(
                    dto => dto.Prices,
                    opt => opt
                        .MapFrom(obj => obj
                            .Dishes.Select(p => p.Price)));

            CreateMap<DishDto, Dish>();

            CreateMap<Tuple<int, decimal>, Dish>()
                .ForMember(
                    obj => obj.Weight,
                    opt => opt
                        .MapFrom(p => p.Item1))
                .ForMember(
                    obj => obj.Price,
                    opt => opt
                        .MapFrom(p => p.Item2));

            CreateMap<DishDto, IEnumerable<Dish>>()
                .ConvertUsing<DishDtoConverter>();
            
            CreateMap<Recipe, RecipeDto>()
                .ForMember(
                    d => d.Ingredients,
                    opt 
                        => opt.MapFrom(s 
                            => s.Ingredients.Select(p => p.Name)));
        }
    }
}