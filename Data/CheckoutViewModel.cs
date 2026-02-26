using Malwaro.Models;

namespace Malwaro.Data
{
    public class CheckoutViewModel
    {
        public Carrinho Carrinho { get; set; }
        public double Total { get; set; }
        public int PedidoId { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
    }
}
