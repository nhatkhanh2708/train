using Domain.Entities.PromotionAggregate;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        IEnumerable<Promotion> Filter(string searchString, System.DateTime? dayFrom, System.DateTime? dayTo, sbyte? status);
    }
}
