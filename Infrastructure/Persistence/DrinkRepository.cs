using Domain.Entities.Product;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class DrinkRepository : EFRepository<Drink>, IDrinkRepository
    {
        public DrinkRepository(DatabaseContext context) : base(context)
        {
        }

        public IEnumerable<Drink> Filter(int? drinkCategoryId, string searchString, decimal? priceFrom, decimal? priceTo, bool? status)
        {
            var query = context.Drinks.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                int id;
                if (int.TryParse(searchString, out id))
                    query = query.Where(m => m.Id == id);
                else
                    query = query.Where(m => m.Name.Contains(searchString));
            }

            if (drinkCategoryId != null)
            {
                query = query.Where(m => m.DrinkCategoryId == drinkCategoryId);
            }

            if (priceFrom != null)
            {
                query = query.Where(m => m.Price >= priceFrom);
            }

            if (priceTo != null)
            {
                query = query.Where(m => m.Price <= priceTo);
            }

            if (status != null)
            {
                query = query.Where(m => m.Status == status);
            }
            return query.ToList();
        }

        public IEnumerable<Drink> GetDrinksByCategoryId(int categoryId)
        {
            return context.Drinks.Where(m => m.DrinkCategoryId == categoryId);
        }
    }
}
