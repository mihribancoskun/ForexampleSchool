using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Modul.AccountManager.Model.Entity;
using SchoolApp.RepoEf;

namespace SchoolApp.Modul.AccountManager
{
  public  class EfDbContext: SchoolAppEfContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserSchool> UserSchool { get; set; }
        public DbSet<School> School { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSchool>()
                .HasKey(c => new { c.UserId, c.SchoolId});
        }
    }
}
