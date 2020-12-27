using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly IDrinkRepository drinkRepository;
        public DrinkService(IDrinkRepository drinkRepository)
        {
            this.drinkRepository = drinkRepository;
        }

        public void CreateDrink(DrinkDto drinkDto)
        {
            var drink = drinkDto.MappingDrink();
            drinkRepository.Add(drink);
        }

        public void UpdateDrink(DrinkDto drinkDto)
        {
            var drink = drinkRepository.GetBy(drinkDto.Id);
            drinkDto.MappingDrink(drink);
            drinkRepository.Update(drink);
        }

        public void DeleteDrink(int drinkId)
        {
            var drink = drinkRepository.GetBy(drinkId);
            drinkRepository.Delete(drink);
            
        }

        public DrinkDto GetDrink(int drinkId)
        {
            var drink = drinkRepository.GetBy(drinkId);
            return drink.MappingDto();
        }

        public IEnumerable<DrinkDto> GetDrinksByCategoryId(int categoryId)
        {
            return drinkRepository.GetDrinksByCategoryId(categoryId).MappingDtos();
        }

        public IEnumerable<DrinkDto> GetDrinks(int? drinkCategoryId, string searchString, decimal? priceFrom, decimal? priceTo, bool? status)
        {
            var drinks = drinkRepository.Filter(drinkCategoryId, searchString, priceFrom, priceTo, status);
            return drinks.MappingDtos();
        }
    }
}
