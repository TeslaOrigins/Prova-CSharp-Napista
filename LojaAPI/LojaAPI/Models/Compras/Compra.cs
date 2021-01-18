using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LojaAPI.Models.Compras;

namespace LojaAPI.Models.Compra
{
    public class Compra
    {
        public int Id { get; set; }
        public int Produto_id { get; set; }
        public int Qtde_comprada { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public String Titular { get; set; }
        [StringLength(22, MinimumLength = 13)]
        public String Numero { get; set; }
        [Display(Name = "Data expiracao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd:0}", ApplyFormatInEditMode = true)]
        public DateTime Data_expiracao { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public String Bandeira { get; set; }
        [Range(100, 1000)]
        [DataType(DataType.Currency)]
        public int Cvv { get; set; }
    }
}
