using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
   public class Member
    {
        public int Id { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
        
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        
        public ICollection<MemberPost> MemberPosts { get; set; }
    }
}
