using RestaurantService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RestaurantService.DAL.Utils
{
    class Initializer
    {
        public static void Init(EntityContext context)
        {
            List<string> _ingredients = new List<string>()
            {
                "beef",         // 1
                "soy sauce",    // 2
                "ginger",       // 3 
                "salt",         // 4
                "black pepper", // 5
                "basil",        // 6
                "mustard",      // 7
                "lemon",        // 8
                "flour",        // 9
                "cheese",       //10
                "tomatoes",     //11
                "chicken",      //12
                "garlic",       //13
                "cherries",     //14
                "onion",        //15
                "wine",         //16
                "parsley",      //17
                "sausage",      //18
                "eggs",         //19
                "potatoes",     //20
                "salsa",        //21
                "broccoli",     //22
                "cabbage",      //23
                "cranberry",    //24
                "soda",         //25
                "cinnamon",     //26
                "apple",        //27
                "vanilla",      //28
                "powder",       //29
                "nuts",         //30
                "pepper",       //31
                "mayonnaise",   //32
                "vinegar",      //33
                "sugar",        //34
                "bacon",        //35
                "celery",       //36
                "gherkins",     //37
                "paprika",      //38
                "cucumber",     //39
                "olives",       //40
                "raisins",      //41
                "cocoa",        //42
                "cookies",      //43
                "milk",         //44
                "cornstarch"    //45
            };

            foreach(var ingredient in _ingredients)
            {
                context.Ingredients.Add(
                    new Ingredient
                    {
                        Name = ingredient
                    });
                
                context.SaveChanges();
            }

            

            Random rnd = new Random();

            Dictionary<string, List<Tuple<string, decimal, TimeSpan, List<int>>>> categories 
                = new Dictionary<string, List<Tuple<string, decimal, TimeSpan, List<int>>>>()
                {
                    {
                        "Main Dishes", 
                        new List<Tuple<string, decimal, TimeSpan, List<int>>>()
                        {
                            new Tuple<string, decimal, TimeSpan, List<int>>( //1      1,  2,  3,  4,  5, 6,  7,  8
                                "Ginger Steak", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    1,  2,  3,  4,  5, 6,  7,  8
                                }),             

                            new Tuple<string, decimal, TimeSpan, List<int>>( //2      9,  1,  4, 10, 11,
                                "Double Cheeseburger", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    9,  1,  4, 10, 11
                                }),    

                            new Tuple<string, decimal, TimeSpan, List<int>>( //3     12, 13,  4,  5, 15, 8, 16, 17
                                "Lemon Chicken", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    12, 13,  4,  5, 15, 8, 16, 17
                                }),            

                            new Tuple<string, decimal, TimeSpan, List<int>>( //4     12,  9, 10, 11,
                                "Creamy Chicken Lasagna", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    12,  9, 10, 11
                                }),   

                            new Tuple<string, decimal, TimeSpan, List<int>>( //5     18,  9, 10, 19, 20, 21
                                "Mexican Breakfast Pizza", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    18,  9, 10, 19, 20, 21
                                })   
                        }
                    },

                    {
                        "Salads",
                        new List<Tuple<string, decimal, TimeSpan, List<int>>>()
                        {
                            new Tuple<string, decimal, TimeSpan, List<int>>( //6     22, 23, 24, 30,  4, 31
                                "Broccoli Slaw", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    22, 23, 24, 30,  4, 31
                                }),            

                            new Tuple<string, decimal, TimeSpan, List<int>>( //7     22, 12, 30, 15, 32, 33, 34, 35 
                                "Chicken Broccoli Salad", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    22, 12, 30, 15, 32, 33, 34, 35
                                }),   

                            new Tuple<string, decimal, TimeSpan, List<int>>( //8     19, 32, 15, 36, 37,  7,  4,  5, 38
                                "Egg Salad", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    19, 32, 15, 36, 37,  7,  4,  5, 38
                                }),                

                            new Tuple<string, decimal, TimeSpan, List<int>>( //9     39, 11, 10, 15, 40
                                "Oia Greek Salad", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {                               
                                    39, 11, 10, 15, 40                                 
                                }),          
                                                                
                            new Tuple<string, decimal, TimeSpan, List<int>>( //10    20, 35, 19, 22, 10,  4,  5
                                "Creamy potatoes Salad", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    20, 35, 19, 22, 10,  4,  5
                                })     
                        }
                    },

                    {
                        "Desserts",
                        new List<Tuple<string, decimal, TimeSpan, List<int>>>()
                        {
                            new Tuple<string, decimal, TimeSpan, List<int>>( //11     9, 25, 26,  4, 34, 19, 27, 30, 41
                                "Apple Cake", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    9, 25, 26,  4, 34, 19, 27, 30, 41
                                }),               

                            new Tuple<string, decimal, TimeSpan, List<int>>( //12    10, 34, 42, 28, 19, 14, 43
                                "Black Forest Cheesecake", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    10, 34, 42, 28, 19, 14, 43
                                }),  

                            new Tuple<string, decimal, TimeSpan, List<int>>( //13     9,  4, 29, 44, 34, 45, 14
                                "Cherry Cobbler", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    9,  4, 29, 44, 34, 45, 14
                                }),           

                            new Tuple<string, decimal, TimeSpan, List<int>>( //14     9,  4, 34, 19, 28,  8, 44
                                "Lemon Cupcake", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    9,  4, 34, 19, 28,  8, 44
                                }),

                            new Tuple<string, decimal, TimeSpan, List<int>>( //15    34, 42,  9, 44, 28, 19
                                "Chocolate Pie", 
                                (decimal)rnd.NextDouble(),
                                new TimeSpan(0, rnd.Next(1, 10), 0),
                                new List<int>()
                                {
                                    34, 42,  9, 44, 28, 19
                                })             
                        }
                    }
                };

            List<Recipe> recipes = new List<Recipe>();
            
            foreach(var category in categories)
            {
                foreach(var recipe in category.Value)
                {
                    List<Ingredient> ingredients = new List<Ingredient>();
                    
                    foreach (var ingId in recipe.Item4)
                    {
                        ingredients.Add(
                            context.Ingredients.Find(ingId));
                    }
                    
                    recipes.Add(
                        new Recipe
                        {
                            Category = category.Key,
                            Name = recipe.Item1,
                            PricePerGram = recipe.Item2,
                            Time = recipe.Item3,
                            Dishes = new List<Dish>()
                            {
                                new Dish() { Weight = 50, Price = 50 * recipe.Item2 },
                                new Dish() { Weight = 100, Price = 100 * recipe.Item2 },
                                new Dish() { Weight = 200, Price = 200 * recipe.Item2 }
                            },
                            Ingredients =  ingredients
                        });
                }
            }
            
            context.Recipes.AddRange(recipes);
            
            context.SaveChanges();
        }
    }
}
