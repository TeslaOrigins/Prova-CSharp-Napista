using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Services;
using LojaAPI.Models.Compra;
using LojaAPI.Models.Misc;
using LojaAPI.Models.Compras;
using LojaAPI.Models;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentosController : ControllerBase
    {
        private readonly CompraDbContext _context;

        public PagamentosController(CompraDbContext context)
        {
            _context = context;
        }

        // POST: api/Pagamentos
        [HttpPost]
        public async Task<ActionResult<Pagamento>> PostAutorizaPagamentos(Pagamento pagamento)
        {
            String estado = "";
            Detalhes detalhes = new Detalhes(pagamento.Valor, estado);
            PagamentoServices ps = new PagamentoServices();

            if (!ps.ValidaPagamento(pagamento.Valor))
            {
                detalhes.Estado = "REJEITADO";
                return Unauthorized(detalhes);
            }

            detalhes.Estado = "APROVADO";

            return Ok(detalhes);
        }
    }
}
