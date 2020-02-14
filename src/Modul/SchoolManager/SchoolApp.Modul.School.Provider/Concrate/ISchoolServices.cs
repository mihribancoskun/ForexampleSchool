using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Modul.School.Provider
{
    public interface ISchoolServices
    {
        List<SchoolViewModel> GetSchool();
        SchoolViewModel GetSchool(int id);

        List<MemberViewModel> GetMember(int schoolId);
        MemberViewModel GetMember(int schoolId,int id);
        List<ParentViewModel> GetParent(int schoolId);
        bool MemberUpdate(MemberViewModel member);
        bool MemberDelete(int key);
        bool MemberAdd(MemberViewModel member);  
        bool ParentUpdate(ParentViewModel parent);
        bool ParentDelete(int key);
        bool ParentAdd(ParentViewModel parent);
    }
}
