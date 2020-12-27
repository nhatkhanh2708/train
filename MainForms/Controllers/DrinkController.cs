using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainForms.Controllers
{
    public class DrinkController
    {
        private readonly IDrinkService drinkService;

        public DrinkController()
        {
            drinkService = (IDrinkService)Startup.ServiceProvider.GetService(typeof(IDrinkService));
        }

        public IEnumerable<DrinkDto> Gets(int? drinkCategoryId, string searchString, decimal? priceFrom, decimal? priceTo, bool? status)
        {
            return drinkService.GetDrinks(drinkCategoryId, searchString, priceFrom, priceTo, status);
        }

        public IEnumerable<DrinkDto> GetsByCategoryId(int categoryId)
        {
            return drinkService.GetDrinksByCategoryId(categoryId);
        }

        public DrinkDto Get(int drinkId)
        {
            return drinkService.GetDrink(drinkId);
        }

        public void Create(DrinkDto drinkDto)
        {
            drinkService.CreateDrink(drinkDto);
        }

        public void Update(DrinkDto drinkDto)
        {
            drinkService.UpdateDrink(drinkDto);
        }

        public void Delete(int drinkId)
        {
            drinkService.DeleteDrink(drinkId);
        }
    }
}
