using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
    public class MemberPost
    {
        public int Id { get; set; }
        public ICollection<MemberSubPost> MemberSubPosts { get; set; }
    }
}
