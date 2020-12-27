using Domain.Entities.ManageAccount;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence
{
    public class AccountRepository : EFRepository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Account> Filter(string searchString, bool? status)
        {
            var query = context.Accounts.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.Username.Contains(searchString));
            }

            if (status != null)
            {
                query = query.Where(m => m.Status == status);
            }
            return query.ToList();
        }

        public Account GetByUsername(string username)
        {
            return context.Accounts.FirstOrDefault(u => u.Username == username);
        }

        public Account GetByStaffId(int staffId)
        {
            return context.Accounts.FirstOrDefault(u => u.StaffId == staffId);
        }

    }
}
