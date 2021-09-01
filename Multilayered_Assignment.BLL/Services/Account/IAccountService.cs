using Multilayered_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multilayered_Assignment.BLL.Services.Account
{
    public interface IAccountService
    {
        List<LoginViewModel> GetAllLoginViews();
        LoginViewModel GetLoginByID(int id);
        LoginViewModel AddLogin(LoginViewModel login);
        LoginViewModel UpdateLoginByID(LoginViewModel login);
    }
}
