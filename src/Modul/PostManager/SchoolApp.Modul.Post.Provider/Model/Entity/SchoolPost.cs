using System;

namespace SchoolApp.Modul.Post.Provider
{
    public class SchoolPost
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime TerminationDate { get; set; }
        public string ImgUrl { get; set; }
    }
}
