using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Modul.Post.Provider.Model.Entity
{
    public class School
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contact { get; set; }
        public string About { get; set; }
        public string Content { get; set; }
    }
}
