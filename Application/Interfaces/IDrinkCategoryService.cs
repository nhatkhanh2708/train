using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDrinkCategoryService
    {
        IEnumerable<DrinkCategoryDto> GetDrinkCategories(string searchString);
        DrinkCategoryDto GetDrinkCategory(int drinkCategoryId);
        void CreateDrinkCategory(DrinkCategoryDto drinkCategoryDto);
        void UpdateDrinkCategory(DrinkCategoryDto drinkCategoryDto);
        void DeleteDrinkCategory(int drinkCategoryId);
    }
}
