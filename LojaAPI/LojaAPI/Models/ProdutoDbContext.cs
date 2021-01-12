﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Models
{
    public class ProdutoDbContext
    {
        public DbSet<Produto> Loja { get; set; }

        public ProdutoDbContext(DbContextOptions<ProdutoDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
        }
    }
}
