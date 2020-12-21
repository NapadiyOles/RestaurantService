using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.DAL.Entities;

namespace RestaurantService.BLL.Profiles
{
    public class DishDtoConverter : ITypeConverter<DishDto, IEnumerable<Dish>>
    {
        public IEnumerable<Dish> Convert(DishDto source, IEnumerable<Dish> destination, ResolutionContext context)
        {
            List<Tuple<int, decimal>> tuples = new List<Tuple<int, decimal>>();

            for (int i = 0; i < 3; i++)
            {
                tuples.Add(
                    new Tuple<int, decimal>(
                        source.Weights.ElementAt(i), 
                        source.Prices.ElementAt(i)));
            }

            foreach (var dish in tuples.Select(tup => context.Mapper.Map<Dish>(tup)))
            {
                context.Mapper.Map(source, dish);

                yield return dish;
            }
        }
    }
}