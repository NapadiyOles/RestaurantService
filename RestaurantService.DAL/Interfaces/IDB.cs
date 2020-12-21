using System;
using RestaurantService.DAL.Repositories;

namespace RestaurantService.DAL.Interfaces
{
    public interface IDB : IDisposable
    {
        IngredientRepository Ingredients { get; }

        RecipeRepository Recipes { get; }

        DishRepository Dishes { get; }

        OrderRepository Orders { get; }
        
        public void Save();
    }
}
