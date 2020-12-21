using System;
using System.Collections;
using System.Collections.Generic;

namespace RestaurantService.DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
