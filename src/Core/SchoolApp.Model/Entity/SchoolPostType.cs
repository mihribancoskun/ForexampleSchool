using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
    public class SchoolPostType
    {
        public int Id { get; set; }
        public ICollection<SchoolPost> SchoolPosts { get; set; }
    }
}
