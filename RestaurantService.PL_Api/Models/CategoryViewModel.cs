using System.Collections.Generic;

namespace RestaurantService.PL_Api.Models
{
    public struct DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<decimal> Prices { get; set; }
    }

    public class CategoryViewModel
    {
        public string Category { get; set; }
        public IEnumerable<DishViewModel> Dishes { get; set; }
    }
}