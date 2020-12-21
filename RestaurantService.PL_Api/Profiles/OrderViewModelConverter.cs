using System.Collections.Generic;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class OrderViewModelConverter : ITypeConverter<OrderDto, OrderViewModel>
    {
        public OrderViewModel Convert(OrderDto source, OrderViewModel destination, ResolutionContext context)
        {
            destination = context.Mapper.Map<OrderViewModel>(source);

            destination.Dishes = context.Mapper.Map<List<OrderedDishViewModel>>(source.Dishes);
            
            return destination;
        }
    }
}