using Multilayered_Assignment.DAL.Data.Repositories.Account;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public LoginViewModel AddLogin(LoginViewModel login)
        {
            var LoginToCheck = _accountRepository.AddLogin(login);

            return _accountRepository.GetLoginID(login.LoginId);
        }

        public List<LoginViewModel> GetAllLoginViews()
        {
            return _accountRepository.GetAllLoginViews().ToList();
        }

        public LoginViewModel GetLoginByID(int id)
        {
            return _accountRepository.GetLoginID(id);
        }

        public LoginViewModel UpdateLoginByID(LoginViewModel login)
        {
            return _accountRepository.UpdateLoginByID(loginId, login);
        }
    }
}
