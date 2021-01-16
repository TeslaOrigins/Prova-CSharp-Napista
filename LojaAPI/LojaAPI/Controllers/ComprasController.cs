using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Services;
using LojaAPI.Models.Compras;
using LojaAPI.Models.Misc;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private const int cem = 100;
        private readonly CompraDbContext _context;

        public ComprasController(CompraDbContext context)
        {
            _context = context;
        }

        // POST: api/Compras
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            String estado = "";
            Detalhes detalhes = new Detalhes(compra.Valor, estado);
            PagamentoServices ps = new PagamentoServices();

            if (!ps.ValidaPagamento(compra))
            {
                detalhes.Estado = "REJEITADO";
                return Unauthorized(detalhes);
            }

            detalhes.Estado = "AUTORIZADO";
            _context.Loja.Add(compra);
            await _context.SaveChangesAsync();

            return Ok(detalhes);
        }
    }
}
