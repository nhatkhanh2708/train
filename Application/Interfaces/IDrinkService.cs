using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDrinkService
    {
        IEnumerable<DrinkDto> GetDrinks(int? drinkCategoryId, string searchString, decimal? priceFrom, decimal? priceTo, bool? status);
        IEnumerable<DrinkDto> GetDrinksByCategoryId(int categoryId);
        DrinkDto GetDrink(int drinkId);
        void CreateDrink(DrinkDto drinkDto);
        void UpdateDrink(DrinkDto drinkDto);
        void DeleteDrink(int drinkId);
    }
}
