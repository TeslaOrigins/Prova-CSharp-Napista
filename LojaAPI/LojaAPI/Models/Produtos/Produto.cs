using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public String Nome { get; set; }
        public double Valor_unitario { get; set; }
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public int Qtde_estoque { get; set; }
    }
}
