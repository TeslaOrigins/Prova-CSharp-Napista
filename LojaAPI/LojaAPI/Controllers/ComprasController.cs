using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Models.Compras;
using LojaAPI.Models;

namespace LojaAPI.Controllers
{
    [Route("api/pagamento/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly CompraDbContext _context;

        public ComprasController(CompraDbContext context)
        {
            _context = context;
        }

        // POST: api/pagamento/compras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra, Cartao cartao)
        {
            try
            {
                if (compra.Cartao.Numero == cartao.Numero)
                {
                    compra.ID_Cartao = cartao.Id;
                    _context.Loja.Add(compra);
                    await _context.SaveChangesAsync();
                }
                if (compra.Cartao.Numero != cartao.Numero)
                {
                    _context.Loja.Add(compra);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    return BadRequest(e.Message);
                }
                throw;
            }
            return Ok();
        }
    }
}
