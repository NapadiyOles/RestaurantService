using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RestaurantService.DAL.Entities;
using RestaurantService.DAL.Interfaces;
using RestaurantService.DAL.Utils;

namespace RestaurantService.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private EntityContext _db { get; }

        public OrderRepository(EntityContext db)
        {
            _db = db;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders
                .Include(obj => obj.Dishes)
                .ThenInclude(innerObj => innerObj.Recipe);
        }

        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public Order GetOne(Expression<Func<Order, bool>> predicate)
        {
            return _db.Orders
                .Include(obj => obj.Dishes)
                .ThenInclude(innerObj => innerObj.Recipe)
                .SingleOrDefault(predicate);
        }
        
        public IEnumerable<Order> GetMany(Expression<Func<Order, bool>> predicate)
        {
            return _db.Orders
                .Include(obj => obj.Dishes)
                .ThenInclude(innerObj => innerObj.Recipe)
                .Where(predicate);
        }

        public void Insert(Order item)
        {
            _db.Orders.Add(item);
        }

        public void Insert(params Order[] items)
        {
            _db.Orders.AddRange(items);
        }

        public void Update(Order item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(params int[] ids)
        {
            Order item = null;

            if ((item = _db.Orders.Find(ids[0])) != null)
                _db.Orders.Remove(item);
        }
    }
}
