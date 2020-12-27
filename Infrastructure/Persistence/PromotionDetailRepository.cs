using Domain.Entities.PromotionAggregate;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class PromotionDetailRepository : EFRepository<PromotionDetail>, IPromotionDetailRepository
    {
        public PromotionDetailRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<PromotionDetail> Filter(int promotionId)
        {
            var query = context.PromotionDetails.AsQueryable();
                query = query.Where(p => p.PromotionId == promotionId);

            return query.ToList();
        }
    }
}
