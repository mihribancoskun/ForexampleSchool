
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Infrastructure;
using SchoolApp.Modul.AccountManager;

namespace SchoolApp.Web.Controllers.mvc
{
    public class EntryController : Controller
    {
        private IAccountServices _accountServices;

        public EntryController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public bool Login(string usr, string pss)
        {

            var result = _accountServices.UserCheck(usr, pss);
            if (result.Result == ResultModelType.Success)
            {
                HttpContext.Session.SetAuth(new AuthModel
                {
                    Email = result.Data.Email,
                    Key = result.Data.Id,
                    Title = result.Data.Name,
                    ActiveSchool = result.Data.Schools?.FirstOrDefault().Id ?? 0,
                    Schools = new Dictionary<int, string>(result.Data?.Schools?.Select(c => new KeyValuePair<int, string>(c.Id, c.Title)).AsQueryable())

                });
                return true;
            }

            return false;
        }
    }
}