using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.DAL.Data.Repositories.Account
{
    public interface IAccountRepository
    {
        IEnumerable<LoginViewModel> GetAllLoginViews();
        LoginViewModel GetLoginID(int id);
        LoginViewModel AddLogin(LoginViewModel login);
        LoginViewModel UpdateLoginByID(LoginViewModel login);
        void Save();
    }
}
