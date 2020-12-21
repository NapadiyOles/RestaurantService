using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.DAL.Entities;
using RestaurantService.DAL.Interfaces;

namespace RestaurantService.BLL.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(d => d.Dishes,
                    opt 
                        => opt.Ignore());

            CreateMap<Order, OrderDto>()
                .ForMember(d => d.Dishes,
                    opt 
                        => opt.Ignore())
                .AfterMap((order, dto) =>
                {
                    var dishes = new List<OrderedDish>();

                    foreach (var dish in order.Dishes)
                    {
                        dishes.Add(new OrderedDish()
                        {
                            Id = dish.Id,
                            Name = dish.Recipe.Name,
                            Weight = dish.Weight,
                            Price = dish.Price
                        });
                    }

                    dto.Dishes = dishes;
                });
        }
    }
}