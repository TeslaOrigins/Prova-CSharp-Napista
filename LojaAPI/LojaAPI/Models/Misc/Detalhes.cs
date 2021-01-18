using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models.Misc
{
    public class Detalhes
    {
        public Detalhes() { }
        public Detalhes(double valor, String estado)
        {
            Valor = valor;
            Estado = estado;
        }
        public double Valor { get; set; }
        public String Estado { get; set; }
    }
}
