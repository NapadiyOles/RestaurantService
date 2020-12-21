using System;
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
    public class RecipeController : ControllerBase
    {
        private IRecipeService _service;
        private IMapper _mapper;

        public RecipeController(IRecipeService service)
        {
            _service = service;

            _mapper = new Mapper(
                new MapperConfiguration(cfg
                    => cfg.AddProfile<RecipeProfile>()));
        }

        [HttpGet]
        public IEnumerable<RecipeViewModel> GetAll()
        {
            var orders = _mapper
                .Map<IEnumerable<RecipeViewModel>>(
                    _service.GetAll());

            return orders;
        }

        [HttpGet("{id}")]
        public DetailedRecipeViewModel Get(int id)
        {
            var order = _mapper
                .Map<DetailedRecipeViewModel>(
                    _service.GetInfo(id));

            return order;
        }

        [HttpPut]
        public void Create(DetailedRecipeViewModel model)
        {
            model.Time = new TimeSpan(0, model.Minutes, model.Seconds);
            var recipe = _mapper
                .Map<RecipeDto>(model);
            
            _service.Add(recipe);
        }

        [HttpPost]
        public void Edit(DetailedRecipeViewModel model)
        {
            model.Time = new TimeSpan(0, model.Minutes, model.Seconds);
            var recipe = _mapper
                .Map<RecipeDto>(model);
            
            _service.Change(recipe);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(
                new RecipeDto {Id = id});
        }
    }
}