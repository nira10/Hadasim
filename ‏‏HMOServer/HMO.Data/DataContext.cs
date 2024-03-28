using HMO.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HMOServer
{
    public class DataContext : DbContext
    {
        //connect to the database
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<Vaccination> Vaccination { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NewHMO_db", b => b.MigrationsAssembly("HMO.API"));
            }
        }

    }
}
