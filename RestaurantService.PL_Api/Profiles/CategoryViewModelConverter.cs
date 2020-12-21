using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RestaurantService.BLL.DtoObjects;
using RestaurantService.PL_Api.Models;

namespace RestaurantService.PL_Api.Profiles
{
    public class CategoryViewModelConverter : ITypeConverter<IEnumerable<DishDto>, IEnumerable<CategoryViewModel>>
    {
        public IEnumerable<CategoryViewModel> Convert(IEnumerable<DishDto> source, IEnumerable<CategoryViewModel> destination, ResolutionContext context)
        {
            var categories = source.GroupBy(
                obj => obj.Category,
                (key, group) 
                    => new CategoryViewModel
                    {
                        Category = key,
                        Dishes = group.Select(obj 
                            => new DishViewModel()
                            {
                                Id = obj.Id,
                                Name = obj.Name,
                                Prices = obj.Prices
                                    .OrderBy(e => e)
                            })
                    });

            return categories;
        }
    }
}