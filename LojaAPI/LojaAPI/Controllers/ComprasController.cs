﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LojaAPI.Services;
using LojaAPI.Models.Compras;
using LojaAPI.Models.Misc;
using LojaAPI.Models.Produtos;
using LojaAPI.Models;
using LojaAPI.Models.Compra;

namespace LojaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly CompraDbContext _context;
        private readonly ProdutoDbContext _context1;

        public ComprasController(CompraDbContext context, ProdutoDbContext context1)
        {
            _context = context;
            _context1 = context1;
        }

        // POST: api/Compras
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(412)]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            ProdutoServices ps = new ProdutoServices(_context1);
            PagamentoServices pgs = new PagamentoServices();
            Detalhes detalhes = new Detalhes();
            detalhes.Estado = "";

            var Produto = ps.GetById(compra.Produto_id);
            if(Produto == null)
            {
                return BadRequest("Produto não encontrado");
            }

            double preco = compra.Qtde_comprada * Produto.Valor_unitario;

            if (!pgs.ValidaPagamento(preco))
            {
                detalhes.Estado = Constantes.REJEITADO;
                detalhes.Valor = preco;
                return BadRequest(detalhes);
            }

            if(Produto.Qtde_estoque > compra.Qtde_comprada)
            {
                Produto.Qtde_estoque = Produto.Qtde_estoque - compra.Qtde_comprada;
                ps.AlteraProduto(Produto, preco, Constantes.FLAG_COMPRA);
            } else
            {
                ps.RemoveProduto(Produto);
            }

            _context.Loja.Add(compra);
            await _context.SaveChangesAsync();

            return Ok("Venda realizada com sucesso");
        }

    }
}
