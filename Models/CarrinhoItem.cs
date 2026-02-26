using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Models
{
    public class CarrinhoItem
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoId { get; set; }
    }
}
