using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.Model
{
   public class SchoolDocumentType
    {
        public int Id { get; set; }
        public ICollection<SchoolDocument> SchoolDocuments { get; set; }
    }
}
