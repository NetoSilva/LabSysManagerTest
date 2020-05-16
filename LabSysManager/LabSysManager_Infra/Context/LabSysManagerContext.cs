using LabSysManager_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LabSysManager_Infra.Context
{
    public class LabSysManagerContext : DbContext
    {
        public LabSysManagerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Cliente

            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().Ignore(c => c.CascadeMode);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("LabSysManager"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
