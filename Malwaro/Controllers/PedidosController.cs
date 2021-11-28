using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Malwaro.Data;
using Malwaro.Models;
using System.Security.Claims;

namespace Malwaro.Controllers
{
    public class PedidosController : Controller
    {
        private readonly MalwaroContext _context;
        private readonly Carrinho _carrinho;

        public PedidosController(MalwaroContext context, Carrinho carrinho)
        {
            _context = context;
            _carrinho = carrinho;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }


            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string UserRole = User.FindFirst(ClaimTypes.Role).Value;

            List<Pedido> pedidos = await _context.Pedido.Include(e => e.PedidoItens).ThenInclude(e => e.Produto).Include(e => e.Usuario).ToListAsync();

            if (UserRole != MalwaroRoles.Admin)
            {
                pedidos = pedidos.Where(e => e.UserId == UserId).ToList();
            }


            return View(pedidos);
        }

        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }


            List<CarrinhoItem> itens = _carrinho.GetItens();

            string UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            List<Pedido> pedidos = await _context.Pedido
                .Include(e => e.PedidoItens).ThenInclude(e => e.Produto)
                .Include(e => e.Usuario).Where(e => e.UserId == UserId).ToListAsync();


            Pedido pedido = new() { UserId = UserId };
            await _context.Pedido.AddAsync(pedido);
            await _context.SaveChangesAsync();

            foreach (CarrinhoItem item in itens)
            {
                PedidoItem pedidoItem = new()
                {
                    Quantidade = item.Quantidade,
                    ProdutoId = item.Produto.Id,
                    PedidoId = pedido.Id,
                    Valor = item.Produto.Valor
                };
                await _context.PedidoItem.AddAsync(pedidoItem);
            }

            await _context.SaveChangesAsync();
            await _carrinho.ClearAsync();

            return View("Success");
        }



        // GET: Pedidos/Carrinho
        public IActionResult Carrinho()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }


            _carrinho.Itens = _carrinho.GetItens();

            CarrinhoViewModel viewModel = new()
            {
                Carrinho = _carrinho,
                Total = _carrinho.GetTotal()
            };

            return View(viewModel);
        }

        public async Task<RedirectToActionResult> AddToCarrinho(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }


            Produto produto = await _context.Produto.FirstOrDefaultAsync(e => e.Id == id);

            if (produto != null)
            {
                _carrinho.Add(produto);
            }

            return RedirectToAction(nameof(Carrinho));
        }

        public async Task<RedirectToActionResult> RemoveFromCarrinho(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }


            Produto produto = await _context.Produto.FirstOrDefaultAsync(e => e.Id == id);

            if (produto != null)
            {
                _carrinho.Remove(produto);
            }

            return RedirectToAction(nameof(Carrinho));
        }
    }
}
