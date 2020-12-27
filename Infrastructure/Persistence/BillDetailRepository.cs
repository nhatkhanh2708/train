using Domain.Entities.BillAggregate;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class BillDetailRepository : EFRepository<BillDetail>, IBillDetailRepository
    {
        public BillDetailRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<BillDetail> GetsByBillId(int billId)
        {
            var query = context.BillDetails.AsQueryable();
            query = query.Where(m => m.BillId == billId);
            return query.ToList();
        }
    }
}
