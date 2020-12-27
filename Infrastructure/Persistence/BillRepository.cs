using Domain.Entities.BillAggregate;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class BillRepository : EFRepository<Bill>, IBillRepository
    {
        public BillRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Bill> Filter(string searchString, DateTime? fromDay, DateTime? toDay)
        {
            var query = context.Bills.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                int id;
                if (int.TryParse(searchString, out id))
                    query = query.Where(m => m.StaffId == id);
            }

            if (fromDay != null)
            {
                query = query.Where(m => m.DayOfSale >= fromDay);
            }

            if (toDay != null)
            {
                query = query.Where(m => m.DayOfSale <= toDay);
            }

            return query.ToList();
        }

        public int GetBillIdLast()
        {
            return context.Bills.Max(p => p.Id);
        }
    }
}
