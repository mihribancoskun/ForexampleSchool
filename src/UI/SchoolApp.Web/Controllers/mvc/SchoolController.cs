using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Modul.School.Provider;

namespace SchoolApp.Web.Controllers.mvc
{
 
    public class SchoolController : Controller
    {
        public ISchoolServices _schoolServices;

        public SchoolController(ISchoolServices schoolServices)
        {
            _schoolServices = schoolServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Update()
        {
            return null;
        }
        public ActionResult Delete()
        {
            return null;
        }
        public ActionResult Detail()
        {
            return View();
        }

        public JsonResult GetSchoolList()
        {
            var _data = _schoolServices.GetSchool();
            return Json(_data);
        }

    }
}