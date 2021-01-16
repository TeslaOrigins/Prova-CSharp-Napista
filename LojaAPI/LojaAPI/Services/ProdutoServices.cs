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

        public Boolean ValidaProduto(Produto produto)
        {
            if (produto == null)
            {
                return false;
            }

            return true;
        }

        public Produto getById(int id)
        {
            var produto = _context.Loja.Find(id);

            if (!ValidaProduto(produto))
            {
                return null;
            }

            return produto;
        }

        /*public IActionResult alteraPorId(int id, Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return null;
        }*/

        public IActionResult alteraPorId(int id, Produto produto)
        {
            ProdutoExists(id);

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        public void addProduto(Produto produto)
        {
            _context.Loja.Add(produto);
            _context.SaveChangesAsync();
        }

        public void removeProduto(Produto produto)
        {
            _context.Loja.Remove(produto);
            _context.SaveChangesAsync();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Loja.Any(e => e.Id == id);
        }
    }
}
