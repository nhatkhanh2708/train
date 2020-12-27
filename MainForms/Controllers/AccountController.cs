using Application.DTOs;
using Application.Interfaces;
using System;
using System.Collections.Generic;

namespace MainForms.Controllers
{
    public class AccountController
    {
        private readonly IAccountService accountService;
        private readonly ISignInManager signInManager;

        public AccountController()
        {
            accountService = (IAccountService)Startup.ServiceProvider.GetService(typeof(IAccountService));

            signInManager = (ISignInManager)Startup.ServiceProvider.GetService(typeof(ISignInManager));
        }

        public string Create(string username, string password, string staffId)
        {
            int _staffId = Int32.Parse(staffId);
            var userToCreate = new AccountDto()
            {
                Username = username,
                StaffId = _staffId,
                Status = true
            };

            var isCreateAcc = accountService.CreateAccount(userToCreate, password);

            return (isCreateAcc)? "You created account of staff successfully." : "User already exists.";
        }

        public void Update(AccountDto accountDto, string password)
        {
            accountService.UpdateAccount(accountDto, password);
        }

        public void Delete(int accountId)
        {
            accountService.DeleteAccount(accountId);
        }

        public IEnumerable<AccountDto> Gets(string searchString, bool? status)
        {
            return accountService.GetAccounts(searchString, status);
        }

        public AccountDto Get(int accountId)
        {
            return accountService.GetAccount(accountId);
        }

        public int GetStaffId(string username)
        {
            return accountService.GetStaffId(username);
        }
        
        public AccountDto GetByStaffId(int staffId)
        {
            return accountService.GetByStaffId(staffId);
        }

        public string Login(string username, string password)
        {
            var _login = signInManager.PasswordSignInAsync(username, password);
            return (_login) ? "" : "WRONG LOGIN ACCOUNT";
        }
    }
}
