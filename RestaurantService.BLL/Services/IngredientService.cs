using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.BLL.Interfaces;
using RestaurantService.DAL.Entities;
using RestaurantService.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestaurantService.BLL.Profiles;

namespace RestaurantService.BLL.Services
{
    public class IngredientService : IIngredientService
    {
        private IDB _db;
        private Mapper _mapper;

        public IngredientService(IDB db)
        {
            _db = db;

            _mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg
                        .AddProfile<IngredientProfile>()));
        }

        public IEnumerable<IngredientDto> GetAll()
        {
            var ingredients = _mapper
                .Map<IEnumerable<IngredientDto>>(
                    _db.Ingredients.GetAll());

            return ingredients;
        }

        public void Add(IngredientDto ingredient)
        {
            if (ingredient is null)
                throw new ArgumentNullException();
            
            if (ingredient.Id != 0)
                throw new ArgumentException("Id needs to be zero");
            
            _db.Ingredients.Insert(_mapper.Map<Ingredient>(ingredient));

            _db.Save();
        }

        public void Delete(IngredientDto ingredient)
        {
            if (ingredient is null)
                throw new ArgumentNullException();
            
            if (ingredient.Id == 0)
                throw new ArgumentException("Id cannot be zero");

            _db.Ingredients.Delete(ingredient.Id);
        
            _db.Save();
    }

        public void Change(IngredientDto ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException();
            
            if (ingredient.Id == 0)
                throw new ArgumentException("Id cannot be zero");
            
            _db.Ingredients.Update(
                _mapper.Map<Ingredient>(ingredient));

            _db.Save();
        }

        public IEnumerable<IngredientDto> Find(string key)
        {
            var ingredients = _mapper.Map<IEnumerable<IngredientDto>>(
                _db.Ingredients.GetMany(obj 
                    => obj.Name.StartsWith(key)));

            return ingredients;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
