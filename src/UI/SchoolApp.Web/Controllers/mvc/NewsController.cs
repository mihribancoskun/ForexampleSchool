using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Modul.Post.Provider;

namespace SchoolApp.Web.Controllers.mvc
{
    public class NewsController : Controller
    {
        ISchoolPostServices _schoolPostServices;

        public NewsController(ISchoolPostServices schoolPostServices)
        {
            _schoolPostServices = schoolPostServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPost()
        {
            var typeList = _schoolPostServices.GetType();
            ViewBag.type = typeList;
            return View(new SchoolPostViewModel());
        }
        public IActionResult DetailPost(int id)
        {
            var _data = _schoolPostServices.GetSchoolPost(HttpContext.Session.GetAuth().Key, id);
            var typeList = _schoolPostServices.GetType();
            ViewBag.type = typeList;
            return View(_data.Data);
        }
        public IActionResult UpdatePost(SchoolPostViewModel model, IFormFile imgFile)
        {
            model.SchoolId = HttpContext.Session.GetAuth().ActiveSchool;


            if (imgFile != null)
            {
                var filePath = Path.Combine("wwwroot/UploadFile/",
                                   Path.GetRandomFileName()).Replace(".", "") + imgFile.FileName;
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                using (var localFile = System.IO.File.OpenWrite(filePath))
                using (var uploadedFile = imgFile.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }

                model.ImgUrl = filePath;
            }

            if (model.Id != null && model.Id > 0)
                _schoolPostServices.Update(model);
            else
                _schoolPostServices.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeletePost(int id)
        {
            _schoolPostServices.Delete(id);
            return RedirectToAction("Index");
        }


        public JsonResult GetNews()
        {
            var _model = _schoolPostServices.GetSchoolPost(HttpContext.Session.GetAuth().ActiveSchool);
            return Json(_model);
        }

    }
}