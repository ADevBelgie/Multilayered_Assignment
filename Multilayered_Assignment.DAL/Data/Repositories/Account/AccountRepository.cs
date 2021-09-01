using Multilayered_Assignment.Data;
using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Multilayered_Assignment.DAL.Data.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Multilayered_AssignmentContext _context;
        public AccountRepository(Multilayered_AssignmentContext context)
        {
            _context = context;
        }

        public LoginViewModel AddLogin(LoginViewModel login)
        {
            try
            {
                _context.LoginViewModel.Add(login);
            }
            catch (Exception)
            {

                throw;
            }
            Save();
            return GetLoginID(login.LoginId);
        }

        public IEnumerable<LoginViewModel> GetAllLoginViews()
        {
            return _context.LoginViewModel;
        }

        public LoginViewModel GetLoginID(int id)
        {
            return _context.LoginViewModel.FirstOrDefault(x => x.LoginId == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public LoginViewModel UpdateLoginByID(LoginViewModel login)
        {
            _context.LoginViewModel.Update(login);
            _context.SaveChanges();
            return GetLoginID(login.LoginId);
        }
    }
}
