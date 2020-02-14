using System;
using System.Collections.Generic;
using System.Text;
using SchoolApp.Infrastructure;
using SchoolApp.Modul.Post.Provider;
using System.Linq;

namespace SchoolApp.Modul.Post.Logic.Logic
{
    public class SchoolPostLogic : ISchoolPostServices
    {
        private EfDbContext _context;

        public SchoolPostLogic()
        {
            _context = new EfDbContext();
        }
        public ResultModel<List<SchoolPostViewModel>> GetSchoolPost(int schoolId)
        {
            var resultData = from post in _context.SchoolPost.Where(c => c.SchoolId == schoolId)
                             from type in _context.SchoolPostType.Where(c => c.Id == post.TypeId)
                             select new SchoolPostViewModel
                             {

                                 Id = post.Id,
                                 Content = post.Content,
                                 Title = post.Title,
                                 Type = type.Title,
                                 TypeId = type.Id,
                                 SchoolId = post.SchoolId,
                                 CreateDate = post.CreateDate,
                                 PublishDate = post.PublishDate,
                                 TerminationDate = post.TerminationDate,
                                 PublishDateText = post.PublishDate.ToString("dd/MM/yyyy"),
                                 TerminationDateText = post.TerminationDate.ToString("dd/MM/yyyy"),
                                 ImgUrl =post.ImgUrl
                             };
            return new ResultModel<List<SchoolPostViewModel>>
            {
                Data = resultData?.ToList(),
                Result = resultData == null ? ResultModelType.Warning : ResultModelType.Success,
                Message = resultData == null ? "Data is empty" : ""
            };

        }

        public ResultModel<SchoolPostViewModel> GetSchoolPost(int schoolId, int id)
        {
            var resultData = from post in _context.SchoolPost.Where(c => c.SchoolId == schoolId && c.Id == id)
                             from type in _context.SchoolPostType.Where(c => c.Id == post.TypeId)
                             select new SchoolPostViewModel
                             {
                                 Id = post.Id,
                                 Content = post.Content,
                                 Title = post.Title,
                                 Type = type.Title,
                                 TypeId = type.Id,
                                 SchoolId = post.SchoolId,
                                 CreateDate = post.CreateDate,
                                 PublishDate = post.PublishDate,
                                 TerminationDate = post.TerminationDate,
                                 PublishDateText = post.PublishDate.ToString("dd/MM/yyyy"),
                                 TerminationDateText = post.TerminationDate.ToString("dd/MM/yyyy"),
                                 ImgUrl = post.ImgUrl
                             };
            return new ResultModel<SchoolPostViewModel>
            {
                Data = resultData?.FirstOrDefault(),
                Result = resultData == null ? ResultModelType.Warning : ResultModelType.Success,
                Message = resultData == null ? "Data is empty" : ""
            };

        }

        public ResultModel<int> Add(SchoolPostViewModel model)
        {
            var entityData = new SchoolPost
            {
                Content = model.Content,
                Title = model.Title,
                SchoolId = model.SchoolId,
                TypeId = model.TypeId,
                CreateDate = DateTime.Now,
                PublishDate = model.PublishDate,
                TerminationDate = model.TerminationDate,
                ImgUrl = model.ImgUrl
            };


            _context.SchoolPost.Add(entityData);
            _context.SaveChanges();

            return new ResultModel<int>
            {
                Data = entityData.Id,
                Result = ResultModelType.Success
            };
        }

        public ResultModel Update(SchoolPostViewModel model)
        {
            var entityData = _context.SchoolPost.Find(model.Id);
            // entityData.PublishDate 
            entityData.Content = model.Content;
            entityData.Title = model.Title;
            entityData.TypeId = model.TypeId;
            entityData.PublishDate = model.PublishDate;
            entityData.TerminationDate = model.TerminationDate;
            if (!string.IsNullOrEmpty(model.ImgUrl))
            {
                entityData.ImgUrl = model.ImgUrl;
            }

            var result = _context.SaveChanges();
            return new ResultModel
            {
                Result = result > 0 ? ResultModelType.Success : ResultModelType.Error
            };
        }

        public ResultModel Delete(object key)
        {
            var entityData = _context.SchoolPost.Find(key);
            _context.Remove(entityData);
            var result = _context.SaveChanges();
            return new ResultModel
            {
                Result = result > 0 ? ResultModelType.Success : ResultModelType.Error
            };
        }

        public List<TypeViewModel> GetType()
        {
            var _data = _context.SchoolPostType.ToList();
            return _data.Select(c => new TypeViewModel
            {
                Title = c.Title,
                Id = c.Id
            }).ToList();
        }
    }
}
