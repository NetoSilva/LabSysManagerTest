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
            modelBuilder.Entity<Cliente>().Property(c => c.TipoSanguineo).HasConversion<string>();
            modelBuilder.Entity<Cliente>().Property(c => c.Cor).HasConversion<string>();

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente(
                    "Levi Juan Henrique da Rosa",
                    18,
                    "837.218.376-73",
                    "33.171.161-8",
                    new DateTime(2001, 02, 27),
                     "Araxá",
                     "MG",
                     "Peixes",
                     "Giovanna Bianca Cristiane",
                     "Hugo Antonio Roberto da Rosa",
                     "levijuanhenriquedarosa_@cmfcequipamentos.com.br",
                     "jqAYDrlOk5",
                     "38183-044",
                     715,
                     "(34) 3670-2306",
                     "(34) 99963-1139",
                     "1,73",
                     78,
                     Cliente.ClienteTipoSanguineo.ANegativo,
                     Cliente.ClienteCor.Vermelho
                    )
                );
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
