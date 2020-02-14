using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Modul.Post.Provider;
using SchoolApp.RepoEf;

namespace SchoolApp.Modul.Post.Logic
{
    public class EfDbContext : SchoolAppEfContext
    {
        public DbSet<SchoolApp.Modul.Post.Provider.SchoolDocument> SchoolDocument { get; set; }
        public DbSet<SchoolApp.Modul.Post.Provider.SchoolDocumentType> SchoolDocumentType { get; set; }
        public DbSet<SchoolApp.Modul.Post.Provider.SchoolPost> SchoolPost { get; set; }
        public DbSet<SchoolApp.Modul.Post.Provider.SchoolPostType> SchoolPostType { get; set; }
    }
}
