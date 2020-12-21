using System;

namespace RestaurantService.PL_Api.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal PricePerGram { get; set; }

        public TimeSpan Time { get; set; }
    }
}