using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantService.DAL.Entities;
using RestaurantService.DAL.Interfaces;
using RestaurantService.DAL.Utils;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace RestaurantService.DAL.Repositories
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private EntityContext _db { get; }

        public IngredientRepository(EntityContext db)
        {
            _db = db;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _db.Ingredients;
        }

        public Ingredient Get(int id)
        {
            return _db.Ingredients.Find(id);
        }
        
        public Ingredient GetOne(Expression<Func<Ingredient, bool>> predicate)
        {
            return _db.Ingredients
                .Include(obj => obj.Recipes)
                .SingleOrDefault(predicate);
        } 

        public IEnumerable<Ingredient> GetMany(Expression<Func<Ingredient, bool>> predicate)
        {
            return _db.Ingredients
                .Include(obj => obj.Recipes)
                .Where(predicate);
        }

        public void Insert(Ingredient item)
        {
            _db.Ingredients.Add(item);
        }

        public void Insert(params Ingredient[] items)
        {
            _db.Ingredients.AddRange(items);
        }

        public void Update(Ingredient item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(params int[] ids)
        {
            Ingredient item = null;
            
            if ((item = _db.Ingredients.Find(ids[0])) != null)
                _db.Ingredients.Remove(item);
        }
    }       
}
