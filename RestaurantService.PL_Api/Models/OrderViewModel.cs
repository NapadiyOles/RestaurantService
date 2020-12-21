using System.Collections.Generic;

namespace RestaurantService.PL_Api.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Sum { get; set; }

        public int TableNumber { get; set; }

        public List<OrderedDishViewModel> Dishes { get; set; }
    }
}