using Domain.Entities.PromotionAggregate;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IPromotionDetailRepository : IRepository<PromotionDetail>
    {
        IEnumerable<PromotionDetail> Filter(int promotionId);
    }
}
