using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Modul.Post.Provider
{
    public class SchoolDocumentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public int TypeId { get; set; }
        public int SchoolId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string PublishDateText { get; set; }
        public string TerminationDateText { get; set; }
        public string FileUrl { get; set; }
    }
}
