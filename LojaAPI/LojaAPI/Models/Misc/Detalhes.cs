using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaAPI.Models.Misc
{
    public class Detalhes
    {
        public Detalhes() { }
        public Detalhes(float valor, String estado)
        {
            Valor = valor;
            Estado = estado;
        }
        public float Valor { get; set; }
        public String Estado { get; set; }
    }
}
