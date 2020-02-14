using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
    public class School
    {
        public int Id { get; set; }
        public ICollection<SchoolPost> SchoolPosts { get; set; }
        public ICollection<SchoolDocument> SchoolDocuments { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<ParentSchool> ParentSchools { get; set; }
    }
}
