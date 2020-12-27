using Domain.Entities.Product;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IDrinkRepository : IRepository<Drink>
    {
        IEnumerable<Drink> GetDrinksByCategoryId(int categoryId);

        IEnumerable<Drink> Filter(int? drinkCategoryId, string searchString, decimal? priceFrom, decimal? priceTo, bool? status);
    }
}
