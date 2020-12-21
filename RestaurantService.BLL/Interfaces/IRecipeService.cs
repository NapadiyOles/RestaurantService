using System;
using System.Collections.Generic;
using RestaurantService.BLL.DtoObjects;

namespace RestaurantService.BLL.Interfaces
{
    public interface IRecipeService : IDisposable
    {
        public IEnumerable<RecipeDto> GetAll();

        public RecipeDto GetInfo(int id);

        public void Add(RecipeDto recipeDto);

        public void Delete(RecipeDto recipe);

        public void Change(RecipeDto recipeDto);
    }
}