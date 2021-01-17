using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Services;
using LojaAPI.Models.Produtos;
using LojaAPI.Models.Misc;
using LojaAPI.Models;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoDbContext _context;
        private ProdutoServices ps;

        public ProdutosController(ProdutoDbContext context)
        {
            _context = context;
            ps = new ProdutoServices(_context);
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
            if (ps.GetById(id) == null)
            {
                return NotFound();
            }

            return ps.GetById(id);
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, [FromBody]Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            ps.AlteraPorId(id);

            return NoContent();
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            try
            {
                if(produto.Nome.Length < Constantes.TRES)
                {
                    return ValidationProblem();
                }
                if(produto.Qtde_estoque < Constantes.UM || produto.Qtde_estoque > Constantes.CEM)
                {
                    return ValidationProblem();
                }

                ps.AddProduto(produto);
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
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produto = _context.Loja.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            ps.RemoveProduto(produto);

            return Ok();
        }
    }
}