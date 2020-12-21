using System;
using System.Collections.Generic;
using RestaurantService.BLL.DtoObjects;

namespace RestaurantService.BLL.Interfaces
{
    public interface IOrderService : IDisposable
    {
        public IEnumerable<OrderDto> GetAll();

        public void Add(OrderDto orderDto);

        public void Change(OrderDto orderDto);

        public IEnumerable<string> GetDishNames();

        public void Delete(OrderDto orderDto);

        public IEnumerable<OrderDto> Find(string key);

        public bool CheckDishes(string name);

        public OrderDto GetInfo(int? id);
    }
}