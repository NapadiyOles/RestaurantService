using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantService.BLL.DtoObjects
{
    public struct OrderedDish
    {
        public int Id;
        public string Name;
        public int Weight;
        public decimal Price;
    }
    
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
        public int TableNumber { get; set; }
        public IEnumerable<OrderedDish> Dishes { get; set; }
    }
}