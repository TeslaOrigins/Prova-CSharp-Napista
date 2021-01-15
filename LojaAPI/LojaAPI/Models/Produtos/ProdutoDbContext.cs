using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Connections;

namespace LojaAPI.Models.Produtos
{
    public class ProdutoDbContext : DbContext
    {
        public DbSet<Produto> Loja { get; set; }

        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
        }
    }
}
