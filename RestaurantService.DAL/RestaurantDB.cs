using System;
using RestaurantService.DAL.Interfaces;
using RestaurantService.DAL.Repositories;
using RestaurantService.DAL.Utils;

namespace RestaurantService.DAL
{
    public class RestaurantDB : IDB
    {
        private bool _disposed;

        private EntityContext _context;

        private IngredientRepository _ingredientRepository;

        private RecipeRepository _recipeRepository;

        private OrderRepository _orderRepository;

        private DishRepository _dishRepository;


        public RestaurantDB(string connection) 
            => _context = new EntityContext(connection);


        public IngredientRepository Ingredients 
            => _ingredientRepository ??= new IngredientRepository(_context);


        public RecipeRepository Recipes
            => _recipeRepository ??= new RecipeRepository(_context);


        public OrderRepository Orders 
            => _orderRepository ??= new OrderRepository(_context);


        public DishRepository Dishes 
            => _dishRepository ??= new DishRepository(_context);
        

        public void Save()
            => _context.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _context.Dispose();

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
