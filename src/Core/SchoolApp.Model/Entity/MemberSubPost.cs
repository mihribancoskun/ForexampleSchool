using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
    public class MemberSubPost
    {
        public int Id { get; set; }
        public int MemberPostId { get; set; }
        public MemberPost MemberPost { get; set; }
    }
}
