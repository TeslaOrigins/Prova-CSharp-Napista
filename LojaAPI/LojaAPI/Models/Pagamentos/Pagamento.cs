using LojaAPI.Models.Pagamentos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models.Compras
{
    public class Pagamento
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        [NotMapped]
        public Cartao cartao { get; set; }
    }
}