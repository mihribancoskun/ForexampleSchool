using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolApp.Modul.AccountManager.Model.Entity
{
   public class UserSchool
    {
        [Key]
        [Column(Order =0)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int SchoolId { get; set; }
    }
}
