﻿using System;
using System.Collections.Generic;
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
        public Cartao Cartao { get; set; }
    }
}
