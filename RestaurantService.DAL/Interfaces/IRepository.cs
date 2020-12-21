using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantService.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Insert(T item);

        void Insert(params T[] items);

        void Update(T item);

        void Delete(params int[] ids);
    }
}
