using System;
using System.Collections.Generic;
using System.Text;
using SchoolApp.Infrastructure;

namespace SchoolApp.Modul.AccountManager
{
    public interface IAccountServices
    {
        public ResultModel<UserViewModel> UserCheck(string userName, string password);
        public ResultModel<UserViewModel>  GetUser(int key);
        public ResultModel UpdateUser(UserViewModel user);
    }
}
