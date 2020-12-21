using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.BLL.Interfaces;
using RestaurantService.PL_Api.Models;
using RestaurantService.PL_Api.Profiles;

namespace RestaurantService.PL_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService _service;
        private Mapper _mapper;

        public OrderController(IOrderService service)
        {
            _service = service;
            
            _mapper = new Mapper(
                new MapperConfiguration(cfg 
                    => cfg.AddProfile<OrderProfile>()));
        }
        
        [HttpGet]
        public IEnumerable<OrderViewModel> GetAll()
        {
            var models = _mapper
                .Map<IEnumerable<OrderViewModel>>(
                    _service.GetAll());
            
            return models;
        }
        
        [HttpGet("{id}")]
        public OrderViewModel Get(int id)
        {
            var order = _mapper
                .Map<OrderViewModel>(
                    _service.GetInfo(id));

            return order;
        }

        [HttpPut]
        public void Create(OrderViewModel model)
        {
            var order = _mapper
                .Map<OrderDto>(model);
            
            _service.Add(order);
        }

        [HttpPost]
        public void Edit(OrderViewModel model)
        {
            var order = _mapper
                .Map<OrderDto>(model);
            
            _service.Change(order);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(
                new OrderDto {Id = id});
        }

        [HttpGet("GetDishNames")]
        public IEnumerable<string> GetDishNames()
        {
            return _service.GetDishNames();
        }
    }
}