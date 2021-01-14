using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models.Compras
{
    public class Compra
    {
        public int Valor { get; set; }
        public Cartao Cartao { get; set; }
    }
}
