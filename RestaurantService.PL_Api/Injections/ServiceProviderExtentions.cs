using Microsoft.Extensions.DependencyInjection;
using RestaurantService.BLL.Injections;
using RestaurantService.BLL.Interfaces;
using RestaurantService.BLL.Services;

namespace RestaurantService.PL_Api.Injections
{
    public static class ServiceProviderExtensions
    {
        public static void AddDishService(this IServiceCollection services, string connection)
            => services.AddTransient<IDishService, DishService>(obj 
                => ServiceModule.Init<DishService>(connection));

        public static void AddIngredientService(this IServiceCollection services, string connection)
            => services.AddTransient<IIngredientService, IngredientService>(obj
                => ServiceModule.Init<IngredientService>(connection));
        
        public static void AddOrderService(this IServiceCollection services, string connection)
            => services.AddTransient<IOrderService, OrderService>(obj
                => ServiceModule.Init<OrderService>(connection));
        
        public static void AddRecipeService(this IServiceCollection services, string connection)
            => services.AddTransient<IRecipeService, RecipeService>(obj 
                => ServiceModule.Init<RecipeService>(connection));
    }
}