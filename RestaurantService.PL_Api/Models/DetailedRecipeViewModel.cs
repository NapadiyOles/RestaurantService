using System;
using System.Collections.Generic;

namespace RestaurantService.PL_Api.Models
{
    public class DetailedRecipeViewModel
    {
        public int  Id { get; set; }
        
        public string Name { get; set; }
        
        public TimeSpan Time { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }
        
        public string Category { get; set; }

        public decimal PricePerGram { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}