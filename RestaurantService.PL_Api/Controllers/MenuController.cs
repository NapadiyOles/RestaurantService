using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantService.BLL.Interfaces;
using RestaurantService.PL_Api.Models;
using RestaurantService.PL_Api.Profiles;

namespace RestaurantService.PL_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private IDishService _service;
        private Mapper _mapper;

        public MenuController(IDishService service)
        {
            _service = service;

            _mapper = new Mapper(
                new MapperConfiguration(ctg
                    => ctg.AddProfile<MenuProfile>()));
        }

        [HttpGet]
        public IEnumerable<CategoryViewModel> GetAll()
        {
            var models = _mapper
                .Map<IEnumerable<CategoryViewModel>>(
                    _service.GetAll());

            return models;
        }

        [HttpGet("{id}")]
        public DetailedRecipeViewModel Get(int id)
        {
            var recipe = _mapper
                .Map<DetailedRecipeViewModel>(
                    _service.GetInfo(id));

            return recipe;
        }
    }
}