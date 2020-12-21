using System;
using System.Collections;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.BLL.Interfaces;
using RestaurantService.DAL.Entities;
using RestaurantService.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using RestaurantService.BLL.Profiles;

namespace RestaurantService.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private IDB _db;
        private Mapper _mapper;
        
        public RecipeService(IDB db)
        {
            _db = db;

            _mapper = new Mapper(
                new MapperConfiguration(
                    cfg => cfg
                        .AddProfile<RecipeProfile>()));
        }
        
        public IEnumerable<RecipeDto> GetAll()
        {
            var recipes = _mapper
                .Map<IEnumerable<RecipeDto>>(
                    _db.Recipes.GetAll());

            return recipes;
        }

        public RecipeDto GetInfo(int id)
        {
            if (id == 0)
                throw new ArgumentException("Id cannot be null");
            
            var recipe = _mapper.Map<RecipeDto>(
                _db.Recipes.GetOne(obj
                    => obj.Id == id));

            return recipe;
        }
        
        public void Add(RecipeDto recipeDto)
        {
            if (recipeDto is null)
                throw new ArgumentNullException();

            if (recipeDto.Id != 0)
                throw new ArgumentException("Id needs to be zero");
            
            var recipe = _mapper.Map<Recipe>(recipeDto);

            recipe.Ingredients = AddIngredients(recipeDto.Ingredients);

            recipe.Dishes = AddDishes(recipeDto.PricePerGram);
            
            _db.Recipes.Insert(recipe);
            
            _db.Save();
        }

        public void Delete(RecipeDto recipe)
        {
            if (recipe is null)
                throw new ArgumentNullException();

            if (recipe.Id == 0)
                throw new ArgumentException("Id cannot be zero");
            
            _db.Recipes.Delete(recipe.Id);

            _db.Save();
        }

        public void Change(RecipeDto recipeDto)
        {
            if (recipeDto is null)
                throw new ArgumentNullException();

            if (recipeDto.Id == 0)
                throw new ArgumentException("Id cannot be zero");
            
            var recipe = _db.Recipes.GetOne(obj 
                => obj.Id == recipeDto.Id);

            _mapper.Map(recipeDto, recipe);

            recipe.Ingredients = AddIngredients(recipeDto.Ingredients);

            if (recipe.PricePerGram != recipeDto.PricePerGram)
                recipe.Dishes = ChangeDishes(recipe.Dishes.ToList(), recipeDto.PricePerGram);
            
            _db.Save();
        }
        
        public void Dispose()
        {
            _db.Dispose();
        }

        private List<Ingredient> AddIngredients(IEnumerable<string> ingredients)
        {
            List<Ingredient> _ingredients = new List<Ingredient>();
            
            foreach (var ingredient in ingredients)
            {
                _ingredients.Add(
                    _db.Ingredients.GetOne(obj 
                        => obj.Name == ingredient));
            }

            return _ingredients;
        }

        private List<Dish> AddDishes(decimal price)
        {
            List<Dish> dishes = new List<Dish>()
            {
                new Dish() {Weight = 50, Price = 50 * price},
                new Dish() {Weight = 100, Price = 100 * price},
                new Dish() {Weight = 200, Price = 200 * price}
            };

            return dishes;
        }

        private List<Dish> ChangeDishes(List<Dish> dishes, decimal price)
        {
            dishes.ForEach(e 
                => e.Price = e.Weight * price);

            return dishes;
        }
    }
}

