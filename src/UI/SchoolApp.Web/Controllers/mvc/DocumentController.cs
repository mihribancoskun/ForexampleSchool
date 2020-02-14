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
    public class DocumentController : Controller
    {
        ISchoolDocumentServices _schoolDocumentServices;

        public DocumentController(ISchoolDocumentServices schoolDocumentServices)
        {
            _schoolDocumentServices = schoolDocumentServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDocument()
        {
            var typeList = _schoolDocumentServices.GetType();
            ViewBag.type = typeList;
            return View(new SchoolDocumentViewModel());
        }
        public IActionResult DetailDocument(int id)
        {
            var _data = _schoolDocumentServices.GetSchoolPost(HttpContext.Session.GetAuth().Key, id);
            var typeList = _schoolDocumentServices.GetType();
            ViewBag.type = typeList;
            return View(_data.Data);
        }
        public IActionResult UpdateDocument(SchoolDocumentViewModel model, IFormFile imgFile)
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

                model.FileUrl = filePath;
            }

            if (model.Id != null && model.Id > 0)
                _schoolDocumentServices.Update(model);
            else
                _schoolDocumentServices.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDocument(int id)
        {
            _schoolDocumentServices.Delete(id);
            return RedirectToAction("Index");
        }


        public JsonResult GetDocumnets()
        {
            var _model = _schoolDocumentServices.GetSchoolPost(HttpContext.Session.GetAuth().ActiveSchool);
            return Json(_model);
        }
    }
}