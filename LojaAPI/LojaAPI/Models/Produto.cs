using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }
    }
}
