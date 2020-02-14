using System;
using System.Collections.Generic;
using System.Text;
using SchoolApp.Infrastructure;

namespace SchoolApp.Modul.Post.Provider
{
    public interface ISchoolDocumentServices
    {
        public ResultModel<List<SchoolDocumentViewModel>> GetSchoolPost(int schoolId);
        public ResultModel<SchoolDocumentViewModel> GetSchoolPost(int schoolId, int id);
        public ResultModel<int> Add(SchoolDocumentViewModel model);
        public ResultModel Update(SchoolDocumentViewModel model);
        public ResultModel Delete(object key);
        public List<TypeViewModel> GetType();

    }
}
