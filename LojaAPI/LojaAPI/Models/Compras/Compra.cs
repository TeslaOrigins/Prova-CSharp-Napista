using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LojaAPI.Models.Compras;
using LojaAPI.Models.Pagamentos;

namespace LojaAPI.Models.Compra
{
    public class Compra
    {
        public int Id { get; set; }
        public int Produto_id { get; set; }
        public int Qtde_comprada { get; set; }
        [NotMapped]
        public Cartao cartao { get; set; }
    }
}
