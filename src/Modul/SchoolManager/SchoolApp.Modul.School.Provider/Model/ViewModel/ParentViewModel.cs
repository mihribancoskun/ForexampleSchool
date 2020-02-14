using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace SchoolApp.Modul.School.Provider
{
    public class ParentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SchoolId { get; set; }
    }
}
