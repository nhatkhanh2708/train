using Domain.Entities.StaffAggregate;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IStaffRepository : IRepository<Staff>
    {
        IEnumerable<Staff> Filter(string searchString, string position, bool? status);
    }
}
