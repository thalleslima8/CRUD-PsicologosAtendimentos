using Microsoft.EntityFrameworkCore;
using PacientesAtendimentos.Models;
using PacientesAtendimentos.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PacientesAtendimentos.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Paciente>().HasKey(t => t.Id);
            modelBuilder.Entity<Paciente>().HasMany(t => t.Atendimentos).WithOne(p => p.Paciente);
            modelBuilder.Entity<Paciente>().Property(p => p.Sexo).HasConversion(
                p => p.ToString(),
                p => (Sexo)Enum.Parse<Sexo>(p));
            modelBuilder.Entity<Paciente>().Property(p => p.EstadoCivil).HasConversion(
                p => p.ToString(),
                p => (EstadoCivil)Enum.Parse<EstadoCivil>(p));


            modelBuilder.Entity<Atendimento>().HasKey(a => a.Id);
            modelBuilder.Entity<Atendimento>().HasOne(a => a.Paciente).WithMany(a => a.Atendimentos);

        }
    }
}
