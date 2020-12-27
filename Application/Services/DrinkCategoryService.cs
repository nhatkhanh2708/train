using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class DrinkCategoryService : IDrinkCategoryService
    {
        private readonly IDrinkCategoryRepository drinkCategoryRepository;

        public DrinkCategoryService(IDrinkCategoryRepository drinkCategoryRepository)
        {
            this.drinkCategoryRepository = drinkCategoryRepository;
        }

        public void CreateDrinkCategory(DrinkCategoryDto drinkCategoryDto)
        {
            var drinkCategory = drinkCategoryDto.MappingDrinkCategory();
            drinkCategoryRepository.Add(drinkCategory);
        }

        public void DeleteDrinkCategory(int drinkCategoryId)
        {
            var drinkCategory = drinkCategoryRepository.GetBy(drinkCategoryId);
            drinkCategoryRepository.Delete(drinkCategory);
        }

        public IEnumerable<DrinkCategoryDto> GetDrinkCategories(string searchString)
        {
            var categories = drinkCategoryRepository.Filter(searchString);
            return categories.MappingDtos();
        }

        public DrinkCategoryDto GetDrinkCategory(int drinkCategoryId)
        {
            var drinkCategory = drinkCategoryRepository.GetBy(drinkCategoryId);
            return drinkCategory.MappingDto();
        }

        public void UpdateDrinkCategory(DrinkCategoryDto drinkCategoryDto)
        {
            var drinkCategory = drinkCategoryRepository.GetBy(drinkCategoryDto.Id);
            drinkCategoryDto.MappingDrinkCategory(drinkCategory);
            drinkCategoryRepository.Update(drinkCategory);
        }
    }
}
