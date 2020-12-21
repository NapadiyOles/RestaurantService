using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, OrderViewModel>()
                .ConvertUsing<OrderViewModelConverter>();

            CreateMap<OrderDto, OrderViewModel>();

            CreateMap<OrderedDish, OrderedDishViewModel>();
            
            CreateMap<OrderViewModel, OrderDto>()
                .ConvertUsing<OrderDtoConverter>();

            CreateMap<OrderViewModel, OrderDto>();

            CreateMap<OrderedDishViewModel, OrderedDish>();
        }
    }
}