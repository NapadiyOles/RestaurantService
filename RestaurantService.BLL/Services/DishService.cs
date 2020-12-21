using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.BLL.Interfaces;
using RestaurantService.DAL.Interfaces;
using RestaurantService.BLL.Profiles;
using RestaurantService.DAL.Entities;

namespace RestaurantService.BLL.Services
{
    public class DishService : IDishService
    {
        private IDB _db;
        private Mapper _mapper;

        public DishService(IDB db)
        {
            _db = db;

            _mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg
                        .AddProfile<DishProfile>()));
        }

        public IEnumerable<DishDto> GetAll()
        {
            var menu = _mapper.Map<IEnumerable<DishDto>>(
                _db.Recipes.GetAll().ToList());

            return menu;
        }

        public RecipeDto GetInfo(int Id)
        {
            if (Id == 0)
                throw new ArgumentException("Id cannot be zero");
            
            return _mapper.Map<RecipeDto>(
                _db.Recipes.GetOne(obj 
                    => obj.Id == Id));
        }
        
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
