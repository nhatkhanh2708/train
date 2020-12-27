using Application.Interfaces;
using Domain.Repositories;

namespace Application.Services
{
    public class SignInManager : ISignInManager
    {
        private readonly IAccountRepository accountRepository;

        public SignInManager(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public bool PasswordSignInAsync(string username, string password)
        {
            var user = accountRepository.GetByUsername(username);

            if (user != null)
            {
                if (HashHelper.VerifyHash(password, user.PasswordHash, user.PasswordSalt) && user.Status)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
