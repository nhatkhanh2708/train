using Domain.Entities.Product;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class DrinkCategoryRepository : EFRepository<DrinkCategory>, IDrinkCategoryRepository
    {
        public DrinkCategoryRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<DrinkCategory> Filter(string searchString)
        {
            var query = context.DrinkCategories.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Title.Contains(searchString));
            }
            return query.ToList();
        }
    }
}
