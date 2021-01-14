using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Models.Produtos;
using LojaAPI.Models;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private const int um = 1;
        private const int tres = 3;
        private const int cem = 100;

        private readonly ProdutoDbContext _context;

        public ProdutosController(ProdutoDbContext context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                return await _context.Loja.ToListAsync();
            } catch (Exception e)
            {
                if(e.Source != null)
                {
                    return BadRequest();
                }
            }
            return await _context.Loja.ToListAsync();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var Produto = await _context.Loja.FindAsync(id);

            if (Produto == null)
            {
                return NotFound();
            }

            return Produto;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produtos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Produto>> PostMovie(Produto produto)
        {
            try
            {
                if(produto.Nome.Length < tres)
                {
                    return ValidationProblem();
                }
                if(produto.Qtde_estoque < um || produto.Qtde_estoque > cem)
                {
                    return ValidationProblem();
                }

                _context.Loja.Add(produto);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    return BadRequest();
                }
                throw;
            }
            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeleteMovie(int id)
        {
            var produto = await _context.Loja.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Loja.Remove(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Loja.Any(e => e.Id == id);
        }
    }
}