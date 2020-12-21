using System.Collections.Generic;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class OrderDtoConverter : ITypeConverter<OrderViewModel,OrderDto>
    {
        public OrderDto Convert(OrderViewModel source, OrderDto destination, ResolutionContext context)
        {
            destination = context.Mapper.Map<OrderDto>(source);

            destination.Dishes = context.Mapper.Map<IEnumerable<OrderedDish>>(source.Dishes);

            return destination;
        }
    }
}