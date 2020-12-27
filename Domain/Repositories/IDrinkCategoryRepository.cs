using Domain.Entities.Product;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IDrinkCategoryRepository : IRepository<DrinkCategory>
    {
        IEnumerable<DrinkCategory> Filter(string searchString);
    }
}
