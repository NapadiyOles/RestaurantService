using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.BLL.Interfaces;
using RestaurantService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantService.BLL.Profiles;
using RestaurantService.DAL.Entities;

namespace RestaurantService.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IDB _db;
        private Mapper _mapper;


        public OrderService(IDB db)
        {
            _db = db;

            _mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg
                        .AddProfile<OrderProfile>()));
        }

        public IEnumerable<OrderDto> GetAll()
        {
            var orders = _mapper.Map<IEnumerable<OrderDto>>(
                _db.Orders.GetAll());

            return orders;
        }

        public void Add(OrderDto orderDto)
        {
            if (orderDto is null)
                throw new ArgumentNullException();
            
            if(orderDto.Id != 0)
                throw new ArgumentException("Id needs to be zero");
            
            var order = _mapper.Map<Order>(orderDto);

            order.Dishes = GetDishes(orderDto.Dishes);

            order.Sum = order.Dishes.Select(e
                => e.Price).Sum();

            _db.Orders.Insert(order);

            _db.Save();
        }

        public IEnumerable<string> GetDishNames()
        {
            var dishes = _db.Recipes.GetAll().Select(obj => obj.Name);

            return dishes;
        }

        public void Change(OrderDto orderDto)
        {
            if (orderDto is null)
                throw new ArgumentNullException();
            
            if(orderDto.Id == 0)
                throw new ArgumentException("Id cannot be zero");

            var order = _db.Orders.GetOne(obj
                => obj.Id == orderDto.Id);

            _mapper.Map(orderDto, order);

            order.Dishes = GetDishes(orderDto.Dishes);

            order.Sum = order.Dishes.Select(e
                => e.Price).Sum();

            _db.Save();
        }

        public void Delete(OrderDto orderDto)
        {
            if (orderDto is null)
                throw new ArgumentNullException();
            
            if(orderDto.Id == 0)
                throw new ArgumentException("Id cannot be zero");

            _db.Orders.Delete(orderDto.Id);

            _db.Save();
        }

        public IEnumerable<OrderDto> Find(string key)
        {
            var orders = _mapper.Map<IEnumerable<OrderDto>>(
                _db.Orders.GetMany(obj
                    => obj.Name.StartsWith(key)));

            return orders;
        }

        public OrderDto GetInfo(int? id)
        {
            if (id == 0)
                throw new ArgumentException("Id cannot be zero");
            
            var order =  _mapper.Map<OrderDto>(
                _db.Orders.GetOne(obj
                    => obj.Id == id));
            
            return order;
        }

        public bool CheckDishes(string name)
        {
            return _db.Recipes.GetOne(
                obj
                    => obj.Name == name) != null;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        private List<Dish> GetDishes(IEnumerable<OrderedDish> dishes)
        {
            List<Dish> _dishes = new List<Dish>();

            foreach (var dish in dishes)
            {
                _dishes.Add(_db.Dishes.GetOne(obj
                    => obj.Recipe.Name == dish.Name && obj.Weight == dish.Weight));
            }

            return _dishes;
        }
    }
}