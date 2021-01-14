using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models.Compras
{
    public class Cartao
    {
        [StringLength(60, MinimumLength = 3)]
        public String Titular { get; set; }
        [StringLength(19, MinimumLength = 13)]
        public String Numero { get; set; }
        [Display(Name = "Data expiracao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Data_expiracao { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public String Bandeira { get; set; }
        [Range(100, 1000)]
        [DataType(DataType.Currency)]
        public int Cvv { get; set; }
    }
}
