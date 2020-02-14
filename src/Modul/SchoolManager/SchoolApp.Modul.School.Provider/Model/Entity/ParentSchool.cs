using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolApp.Modul.School.Provider
{
 public class ParentSchool
    {
        [Key,Column(Order = 0)]
        public int  ParentId { get; set; }
        [Key,Column(Order = 1)]
        public int  SchoolId { get; set; }
    }
}
