using System;
using System.Collections.Generic;

namespace RestaurantService.DAL.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal PricePerGram { get; set; }
        public TimeSpan Time { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
