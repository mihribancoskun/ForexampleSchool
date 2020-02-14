using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Modul.School.Provider;
using SchoolApp.RepoEf;

namespace SchoolApp.Modul.School.Logic
{
    public class EfDbContext : SchoolAppEfContext
    {
        public DbSet<SchoolApp.Modul.School.Provider.SchoolEntity> School { get; set; }
        public DbSet<SchoolApp.Modul.School.Provider.Member> Member { get; set; }
        public DbSet<SchoolApp.Modul.School.Provider.Parent> Parent { get; set; }
        public DbSet<SchoolApp.Modul.School.Provider.ParentSchool> ParentSchool { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParentSchool>()
                .HasKey(c => new { c.ParentId, c.SchoolId });
        }

    }
}
