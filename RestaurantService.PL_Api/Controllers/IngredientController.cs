using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.BLL.Interfaces;
using RestaurantService.PL_Api.Profiles;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private IIngredientService _service;

        private IMapper _mapper;

        public IngredientController(IIngredientService service)
        {
            _service = service;

            _mapper = new Mapper(
                new MapperConfiguration(cfg
                    => cfg.AddProfile<IngredientProfile>()));
        }

        [HttpGet]
        public IEnumerable<IngredientViewModel> GetAll()
        {
            var ingredients = _mapper
                .Map<IEnumerable<IngredientViewModel>>(
                    _service.GetAll());

            return ingredients;
        }

        [HttpPut]
        public void Create(IngredientViewModel model)
        {
            var ingredient = _mapper
                .Map<IngredientDto>(model);
            
            _service.Add(ingredient);
        }

        [HttpPost]
        public void Edit(IngredientViewModel model)
        {
            var ingredient = _mapper
                .Map<IngredientDto>(model);
            
            _service.Change(ingredient);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(
                new IngredientDto {Id = id});
        }
    }
}