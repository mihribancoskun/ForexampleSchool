using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolApp.Infrastructure;
using SchoolApp.Modul.Post.Provider;

namespace SchoolApp.Modul.Post.Logic.Logic
{
    public class SchoolDocumentLogic : ISchoolDocumentServices
    {
        private EfDbContext _context;
        public SchoolDocumentLogic()
        {
            _context = new EfDbContext();
        }
        public ResultModel<List<SchoolDocumentViewModel>> GetSchoolPost(int schoolId)
        {

            var resultData = from doc in _context.SchoolDocument.Where(c => c.SchoolId == schoolId)
                             from type in _context.SchoolDocumentType.Where(c => c.Id == doc.TypeId)
                             select new SchoolDocumentViewModel
                             {
                                 Id = doc.Id,
                                 Content = doc.Content,
                                 Title = doc.Title,
                                 Type = type.Title,
                                 TypeId = type.Id,
                                 CreateDate = doc.CreateDate,
                                 PublishDate = doc.PublishDate,
                                 FileUrl = doc.FileUrl,
                                 TerminationDate = doc.TerminationDate,
                                 SchoolId = doc.SchoolId,
                                 PublishDateText = doc.PublishDate.ToString("dd/MM/yyyy"),
                                 TerminationDateText = doc.TerminationDate.ToString("dd/MM/yyyy")
                             };
            return new ResultModel<List<SchoolDocumentViewModel>>
            {
                Data = resultData?.ToList(),
                Result = resultData == null ? ResultModelType.Warning : ResultModelType.Success,
                Message = resultData == null ? "Data is empty" : ""
            };
        }

        public ResultModel<SchoolDocumentViewModel> GetSchoolPost(int schoolId, int id)
        {
            var resultData = from doc in _context.SchoolDocument.Where(c => c.SchoolId == schoolId && c.Id == id)
                             from type in _context.SchoolDocumentType.Where(c => c.Id == doc.TypeId)
                             select new SchoolDocumentViewModel
                             {
                                 Id = doc.Id,
                                 Content = doc.Content,
                                 Title = doc.Title,
                                 Type = type.Title,
                                 TypeId = type.Id,
                                 CreateDate = doc.CreateDate,
                                 PublishDate = doc.PublishDate,
                                 FileUrl = doc.FileUrl,
                                 TerminationDate = doc.TerminationDate,
                                 SchoolId = doc.SchoolId,
                                 PublishDateText = doc.PublishDate.ToString("dd/MM/yyyy"),
                                 TerminationDateText = doc.TerminationDate.ToString("dd/MM/yyyy")
                             };
            return new ResultModel<SchoolDocumentViewModel>
            {
                Data = resultData?.FirstOrDefault(),
                Result = resultData == null ? ResultModelType.Warning : ResultModelType.Success,
                Message = resultData == null ? "Data is empty" : ""
            };
        }

        public ResultModel<int> Add(SchoolDocumentViewModel model)
        {
            var entityData = new SchoolDocument
            {
                Content = model.Content,
                Title = model.Title,
                SchoolId = model.SchoolId,
                TypeId = model.TypeId,
                CreateDate = DateTime.Now,
                PublishDate = model.PublishDate,
                TerminationDate = model.TerminationDate,
                FileUrl = model.FileUrl,
            };
            _context.SchoolDocument.Add(entityData);
            _context.SaveChanges();
            return new ResultModel<int>
            {
                Data = entityData.Id,
                Result = ResultModelType.Success
            };
        }

        public ResultModel Update(SchoolDocumentViewModel model)
        {
            var entiyData = _context.SchoolDocument.Find(model.Id);
            entiyData.Content = model.Content;
            entiyData.Title = model.Title;
            entiyData.TypeId = model.TypeId;
            entiyData.PublishDate = model.PublishDate;
            entiyData.TerminationDate = model.TerminationDate;
            entiyData.TypeId = model.TypeId;
            if (!string.IsNullOrEmpty(entiyData.FileUrl))
                entiyData.FileUrl = model.FileUrl;


            var result = _context.SaveChanges();
            return new ResultModel
            {
                Result = result > 0 ? ResultModelType.Success : ResultModelType.Error
            };

        }

        public ResultModel Delete(object key)
        {
            var entityData = _context.SchoolDocument.Find(key);
            var result = _context.SaveChanges();
            return new ResultModel
            {
                Result = result > 0 ? ResultModelType.Success : ResultModelType.Error
            };

        }

        public List<TypeViewModel> GetType()
        {
            var _data = _context.SchoolDocumentType.ToList();
            return _data.Select(c => new TypeViewModel
            {
                Title = c.Title,
                Id = c.Id
            }).ToList();
        }
    }
}
