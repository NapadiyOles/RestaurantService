using System;
using System.Collections.Generic;

namespace RestaurantService.BLL.DtoObjects
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal PricePerGram { get; set; }
        public TimeSpan Time { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }
}
