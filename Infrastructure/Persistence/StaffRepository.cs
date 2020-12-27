using Domain.Entities.StaffAggregate;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class StaffRepository : EFRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Staff> Filter(string searchString, string position, bool? status)
        {
            var query = context.Staffs.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                int id;
                if (int.TryParse(searchString, out id))
                    query = query.Where(m => m.Id == id);
                else
                    query = query.Where(m => m.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(position))
            {
                query = query.Where(m => m.Position == position);
            }

            if (status != null)
            {
                query = query.Where(m => m.Status == status);
            }

            return query.ToList();
        }
    }
}
