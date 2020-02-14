using System;
using System.Collections.Generic;
using System.Text;
using SchoolApp.Infrastructure;

namespace SchoolApp.Modul.Post.Provider
{
    public interface ISchoolPostServices
    {
        public ResultModel<List<SchoolPostViewModel>>  GetSchoolPost(int schoolId);
        public ResultModel<SchoolPostViewModel> GetSchoolPost(int schoolId , int id);
        public ResultModel<int> Add(SchoolPostViewModel model);
        public ResultModel Update(SchoolPostViewModel model);
        public ResultModel Delete(object key);
        public List<TypeViewModel> GetType();
    }
}
