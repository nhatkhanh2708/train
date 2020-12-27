using Application.DTOs;
using Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MainForms.Controllers
{
    public class DrinkCategoryController
    {
        private readonly IDrinkCategoryService drinkCategoryService;

        public DrinkCategoryController()
        {
            drinkCategoryService = (IDrinkCategoryService)Startup.ServiceProvider.GetService(typeof(IDrinkCategoryService));
        }

        public IEnumerable<DrinkCategoryDto> Gets(string searchString)
        {
            return drinkCategoryService.GetDrinkCategories(searchString);
        }

        public DrinkCategoryDto Get(int drinkCategoryId)
        {
            return drinkCategoryService.GetDrinkCategory(drinkCategoryId);
        }

        public void Create(DrinkCategoryDto drinkCategoryDto)
        {
            drinkCategoryService.CreateDrinkCategory(drinkCategoryDto);
        }

        public void Update(DrinkCategoryDto drinkCategoryDto)
        {
            drinkCategoryService.UpdateDrinkCategory(drinkCategoryDto);
        }

        public void Delete(int drinkCategoryId)
        {
            drinkCategoryService.DeleteDrinkCategory(drinkCategoryId);
        }

        public bool IsIdEmptyInDrinks(int categoryid)
        {
            var drinkController = new DrinkController();
            var drinks = drinkController.GetsByCategoryId(categoryid);
            return (drinks.Count() == 0) ? true : false;
        }
    }
}
