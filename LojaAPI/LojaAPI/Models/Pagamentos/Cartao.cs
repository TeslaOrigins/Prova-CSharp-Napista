using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models.Pagamentos
{
    [NotMapped]
    public class Cartao
    {
        [StringLength(100, MinimumLength = 3)]
        public string Titular { get; set; }
        [StringLength(22, MinimumLength = 13)]
        public string Numero { get; set; }
        public string Data_expiracao { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string Bandeira { get; set; }
        public string Cvv { get; set; }
    }
}
