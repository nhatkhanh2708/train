using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<AccountDto> GetAccounts(string searchString, bool? status);
        AccountDto GetAccount(int accountId);
        AccountDto GetByStaffId(int staffId);
        bool CreateAccount(AccountDto accountDto, string password);
        void UpdateAccount(AccountDto accountDto, string password);
        void DeleteAccount(int accountId);
        bool UserExists(string username);
        int GetStaffId(string username);
    }
}
