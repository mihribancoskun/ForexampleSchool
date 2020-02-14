using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Modul.School.Provider;

namespace SchoolApp.Web.Controllers.mvc
{
    public class MemberController : Controller
    {

        public ISchoolServices _schoolServices;

        public MemberController(ISchoolServices schoolServices)
        {
            _schoolServices = schoolServices;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult MemberAdd()
        {
            var _parent = _schoolServices.GetParent(HttpContext.Session.GetAuth().Key);
            ViewBag.parent = _parent;
            return View(new MemberViewModel());
        }
        public IActionResult MemberDelete(int id)
        {
            _schoolServices.MemberDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult MemberDetail(int id)
        {
            var model = _schoolServices.GetMember(HttpContext.Session.GetAuth().Key, id);
            var _parent = _schoolServices.GetParent(HttpContext.Session.GetAuth().Key);
            ViewBag.parent = _parent;
            return View(model);
        }
        [HttpPost]
        public IActionResult MemberUpdate(MemberViewModel model)
        {
            if (model.Id != null && model.Id > 0)
                _schoolServices.MemberUpdate(model);
            else
                _schoolServices.MemberAdd(model);
            return RedirectToAction("Index");
        }


        public IActionResult ParentList()
        {
            var model = _schoolServices.GetParent(HttpContext.Session.GetAuth().Key);
            return View(model);
        }
        [HttpPost]
        public bool ParentAdd(ParentViewModel model)
        {
            return _schoolServices.ParentAdd(model);
        }

        public JsonResult GetMember()
        {
            var model = _schoolServices.GetMember(HttpContext.Session.GetAuth().ActiveSchool);
            return Json(model);
        }
    }
}