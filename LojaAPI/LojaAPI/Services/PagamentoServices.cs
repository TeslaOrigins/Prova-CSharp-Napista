using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaAPI.Models;
using LojaAPI.Models.Compras;
using LojaAPI.Models.Misc;
using LojaAPI.Models.Produtos;

namespace LojaAPI.Services
{
    public class PagamentoServices
    {
        public Boolean ValidaPagamento(Double valor)
        {
            if (valor <= Constantes.CEM)
            {
                return false;
            }

            return true;
        }
    }
}
