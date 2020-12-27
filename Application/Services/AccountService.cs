using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using System.Collections.Generic;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public bool CreateAccount(AccountDto accountDto, string password)
        {
            if (UserExists(accountDto.Username))
                return false;

            byte[] passwordHash, passwordSalt;
            HashHelper.CreateHash(password, out passwordHash, out passwordSalt);
            accountDto.PasswordHash = passwordHash;
            accountDto.PasswordSalt = passwordSalt;            
            var account = accountDto.MappingAccount();
            accountRepository.Add(account);
            return true;
        }

        public void DeleteAccount(int accountId)
        {
            var account = accountRepository.GetBy(accountId);
            accountRepository.Delete(account);
        }

        public AccountDto GetAccount(int accountId)
        {
            var account = accountRepository.GetBy(accountId);
            return account.MappingDto();
        }

        public AccountDto GetByStaffId(int staffId)
        {
            var acc = accountRepository.GetByStaffId(staffId);
            if (acc == null)
                return null;
            return acc.MappingDto();
        }

        public IEnumerable<AccountDto> GetAccounts(string searchString, bool? status)
        {
            var accounts = accountRepository.Filter(searchString, status);
            return accounts.MappingDtos();
        }

        public int GetStaffId(string username)
        {
            var user = accountRepository.GetByUsername(username);
            return user.Id;
        }

        public void UpdateAccount(AccountDto accountDto, string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                byte[] passwordHash, passwordSalt;
                HashHelper.CreateHash(password, out passwordHash, out passwordSalt);
                accountDto.PasswordHash = passwordHash;
                accountDto.PasswordSalt = passwordSalt;
            }

            var account = accountRepository.GetBy(accountDto.Id);
            accountDto.MappingAccount(account);
            accountRepository.Update(account);
        }

        public bool UserExists(string username)
        {
            var user = accountRepository.GetByUsername(username);
            return user != null;
        }
    }
}
