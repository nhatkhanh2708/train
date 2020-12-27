using Domain.Entities.BillAggregate;
using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        int GetBillIdLast();
        IEnumerable<Bill> Filter(string searchString, DateTime? fromDay, DateTime? toDay);
    }
}
