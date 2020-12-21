using System;
using System.Collections.Generic;
using RestaurantService.BLL.DtoObjects;

namespace RestaurantService.BLL.Interfaces
{
    public interface IIngredientService : IDisposable
    {
        public IEnumerable<IngredientDto> GetAll();

        public void Add(IngredientDto ingredient);

        public void Delete(IngredientDto ingredient);

        public void Change(IngredientDto ingredient);

        public IEnumerable<IngredientDto> Find(string key);
    }
}