using Domain.Entities.BillAggregate;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IBillDetailRepository : IRepository<BillDetail>
    {
        IEnumerable<BillDetail> GetsByBillId(int billId);
    }
}
