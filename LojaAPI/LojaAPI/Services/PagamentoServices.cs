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
        private const int cem = 100;
        public Boolean ValidaPagamento(Compra compra)
        {
            if (compra.Valor <= cem)
            {
                return false;
            }

            return true;
        }

        /*public Boolean getById(int id)
        {

        }*/
    }
}
