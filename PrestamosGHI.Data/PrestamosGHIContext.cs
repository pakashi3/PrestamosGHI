using Microsoft.EntityFrameworkCore;
using PrestamosGHI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrestamosGHI.Data
{
    public class PrestamosGHIContext : DbContext
    {
        public PrestamosGHIContext(DbContextOptions<PrestamosGHIContext> options) :
            base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CalculoList> CalculoLists { get; set; }

        public DbSet<Gasto> Gastos { get; set; }

        public DbSet<Pago> Pagos { get; set; }

        public DbSet<Prestamo> Prestamos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cliente>().HasMany(c => c.IdClientes)
        //        .WithOne(prop => prop.IdClientes)
        //        .HasForeignKey(p => p.IdClientes);

        //    modelBuilder.Entity<Cliente>().Property(c => c.Nombre).HasMaxLength(50);
        //    modelBuilder.Entity<Cliente>().Property(c => c.Nombre).IsRequired(true);

    }
}
