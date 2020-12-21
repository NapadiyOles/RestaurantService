
using System.Collections;
using System.Collections.Generic;

namespace RestaurantService.DAL.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
