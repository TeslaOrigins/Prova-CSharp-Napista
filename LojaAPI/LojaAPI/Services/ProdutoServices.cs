using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LojaAPI.Models;
using LojaAPI.Models.Produtos;
using LojaAPI.Models.Misc;
using Microsoft.EntityFrameworkCore;

namespace LojaAPI.Services
{
    public class ProdutoServices
    {
        private readonly ProdutoDbContext _context;

        public ProdutoServices(ProdutoDbContext context)
        {
            _context = context;
        }

        public ProdutoServices() { }

        public Boolean ValidaProduto(Produto produto)
        {
            if (produto == null)
            {
                return false;
            }

            return true;
        }

        public Produto GetById(int id)
        {
            var produto = _context.Loja.Find(id);

            if (!ValidaProduto(produto))
            {
                return null;
            }

            return produto;
        }

        public IActionResult AlteraProduto(Produto produto)
        {
            ProdutoExists(produto.Id);
            Produto produto1 = GetById(produto.Id);
            try
            {
                produto1.Nome = produto.Nome;
                produto1.Qtde_estoque = produto.Qtde_estoque;
                produto1.Valor_unitario = produto.Valor_unitario;

                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(produto.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }

        public void AddProduto(Produto produto)
        {
            _context.Loja.Add(produto);
            _context.SaveChanges();
        }

        public void RemoveProduto(Produto produto)
        {
            _context.Loja.Remove(produto);
            _context.SaveChanges();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Loja.Any(e => e.Id == id);
        }
    }
}
