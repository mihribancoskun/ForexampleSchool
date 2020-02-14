using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Modul.School.Provider
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ParentName { get; set; }
        public int ParentId { get; set; }
        public string SchoolNo { get; set; }
    }
}
