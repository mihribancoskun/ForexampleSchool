using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
   public class SchoolDocument
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }

        public int SchoolDocumentTypeId { get; set; }
        public SchoolDocumentType SchoolDocumentType { get; set; }
    }
}
