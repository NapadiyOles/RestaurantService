using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantService.BLL.DtoObjects
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> Weights { get; set; }
        public IEnumerable<decimal> Prices { get; set; }
    }
}
