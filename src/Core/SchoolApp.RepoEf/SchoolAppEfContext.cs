using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolApp.Model;

namespace SchoolApp.RepoEf
{
    public abstract class SchoolAppEfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-51CC5H2;Database=SchoolApp;Trusted_Connection=True;");
        }
    }
}
