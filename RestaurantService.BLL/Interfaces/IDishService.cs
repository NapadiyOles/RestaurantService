using System;
using System.Collections.Generic;
using RestaurantService.BLL.DtoObjects;

namespace RestaurantService.BLL.Interfaces
{
    public interface IDishService : IDisposable
    {
        public IEnumerable<DishDto> GetAll();
        public RecipeDto GetInfo(int id);
    }
}