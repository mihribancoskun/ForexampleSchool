using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolApp.Modul.School.Provider;
using SchoolApp.Web.Models;

namespace SchoolApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ISchoolServices _schoolServices { get; set; }

        public HomeController(ILogger<HomeController> logger, ISchoolServices schoolServices)
        {
            _logger = logger;
            _schoolServices = schoolServices;
        }

        public IActionResult Index()
        {
            var data = _schoolServices.GetSchool();

            return View();
        }   

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
