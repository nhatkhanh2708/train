using Domain.Entities.PromotionAggregate;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class PromotionRepository : EFRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Promotion> Filter(string searchString, DateTime? dayFrom, DateTime? dayTo, sbyte? status)
        {
            var query = context.Promotions.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                int id;
                if (int.TryParse(searchString, out id))
                    query = query.Where(m => m.Id == id);
                else
                    query = query.Where(m => m.Title.Contains(searchString));
            }

            if(dayFrom != null)
                query = query.Where(m => m.StartDate >= dayFrom);

            if(dayTo != null)
                query = query.Where(m => m.FinishDate <= dayTo);

            if (status != null)
            {
                query = query.Where(m => m.Status == status);
            }

            return query.ToList();
        }
    }
}
