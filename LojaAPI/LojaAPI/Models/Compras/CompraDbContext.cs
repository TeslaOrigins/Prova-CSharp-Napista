using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Models.Compras
{
    public class CompraDbContext : DbContext
    {
        public DbSet<Compra> Loja { get; set; }

        public CompraDbContext(DbContextOptions<CompraDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>().ToTable("Compra");
        }
    }
}
