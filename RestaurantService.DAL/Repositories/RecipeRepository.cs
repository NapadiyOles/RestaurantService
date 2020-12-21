using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantService.DAL.Entities;
using RestaurantService.DAL.Interfaces;
using RestaurantService.DAL.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RestaurantService.DAL.Repositories
{
    public class RecipeRepository : IRepository<Recipe> 
    {
        private EntityContext _db { get; }

        public RecipeRepository(EntityContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return _db.Recipes
                .Include(obj => obj.Ingredients)
                .Include(p => p.Dishes);
        }

        public Recipe GetOne(Expression<Func<Recipe, bool>> predicate)
        {
            return _db.Recipes
                .Include(obj => obj.Dishes)
                .Include(obj => obj.Ingredients)
                .SingleOrDefault(predicate);
        }
        
        public Recipe Get(int id)
        {
            return _db.Recipes.Find(id);
        }

        public IEnumerable<Recipe> GetMany(Expression<Func<Recipe, bool>> predicate)
        {
            return _db.Recipes.Where(predicate);
        }
        
        public void Insert(Recipe item)
        {
            _db.Recipes.Add(item);
        }

        public void Insert(params Recipe[] items)
        {
            _db.Recipes.AddRange(items);
        }

        public void Update(Recipe item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(params int[] ids)
        {
            Recipe item = null;

            if ((item = _db.Recipes.Find(ids[0])) != null)
                _db.Recipes.Remove(item);
        }
    }
}
