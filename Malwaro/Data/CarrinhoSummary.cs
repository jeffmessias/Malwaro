using Malwaro.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Data
{
    public class CarrinhoSummary:ViewComponent
    {
        private readonly Carrinho _carrinho;

        public CarrinhoSummary(Carrinho carrinho)
        {
            _carrinho = carrinho;
        }

        public IViewComponentResult Invoke()
        {
            List<CarrinhoItem> itens = _carrinho.GetItens();
            return View(itens.Count);
        }
    }
}
