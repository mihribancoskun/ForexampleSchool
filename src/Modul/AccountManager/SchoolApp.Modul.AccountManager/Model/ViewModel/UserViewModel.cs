using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Modul.AccountManager
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<SchoolViewModel> Schools { get; set; }
    }

    public class SchoolViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
