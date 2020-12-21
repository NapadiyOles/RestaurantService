using System.Collections.Generic;

namespace RestaurantService.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
        public int TableNumber { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}
