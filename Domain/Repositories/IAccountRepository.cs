using Domain.Entities.ManageAccount;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> Filter(string searchString, bool? status);
        Account GetByUsername(string username);
        Account GetByStaffId(int staffId);
    }
}
