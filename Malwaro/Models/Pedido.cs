﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Usuario Usuario { get; set; }
        

        public List<PedidoItem> PedidoItens { get; set; }

    }
}
