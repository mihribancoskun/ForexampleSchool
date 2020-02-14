﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web
{
    public class AuthModel
    {
        public int Key { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public Dictionary<int,string> Schools { get; set; }
        public int ActiveSchool { get; set; }
    }
}
