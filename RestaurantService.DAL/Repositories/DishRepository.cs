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
    public class DishRepository : IRepository<Dish>
    {
        private EntityContext _db { get; }

        public DishRepository(EntityContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Dish> GetAll()
        {
            return _db.Dishes;
        }

        public Dish Get(int id)
        {
            return _db.Dishes.Find(id);
        }

        public Dish GetOne(Expression<Func<Dish, bool>> predicate)
        {
            return _db.Dishes
                .Include(obj => obj.Recipe)
                .SingleOrDefault(predicate);
        }

        public IEnumerable<Dish> GetMany(Expression<Func<Dish, bool>> predicate)
        {
            return _db.Dishes.Where(predicate);
        }

        public void Insert(Dish item)
        {
            _db.Dishes.Add(item);
        }

        public void Insert(params Dish[] items)
        {
            _db.Dishes.AddRange(items);
        }

        public void Update(Dish item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(params int[] ids)
        {
            Dish item = null;

            if ((item = _db.Dishes.Find(ids)) != null)
                _db.Dishes.Remove(item);
        }
    }
}
