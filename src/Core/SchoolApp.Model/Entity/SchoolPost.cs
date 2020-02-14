using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
  public  class SchoolPost
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public int SchoolPostTypeId { get; set; }
        public SchoolPostType SchoolPostType { get; set; }
    }
}
