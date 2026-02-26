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

            Pedido pedido = new() { UserId = UserId, Status = StatusPagamento.Pendente, MetodoPagamento = MetodoPagamento.Nenhum };
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

            return RedirectToAction(nameof(Checkout), new { pedidoId = pedido.Id });
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

        // GET: Pedidos/Checkout
        public async Task<IActionResult> Checkout(int pedidoId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var pedido = await _context.Pedido
                .Include(e => e.PedidoItens)
                .ThenInclude(e => e.Produto)
                .FirstOrDefaultAsync(e => e.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound();
            }

            double total = pedido.PedidoItens.Sum(e => e.Quantidade * e.Valor);

            var viewModel = new CheckoutViewModel
            {
                Carrinho = _carrinho,
                Total = total,
                PedidoId = pedidoId,
                MetodoPagamento = MetodoPagamento.Nenhum
            };

            return View(viewModel);
        }

        // POST: Pedidos/ProcessarPagamento
        [HttpPost]
        public async Task<IActionResult> ProcessarPagamento(int pedidoId, MetodoPagamento metodoPagamento)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var pedido = await _context.Pedido.FirstOrDefaultAsync(e => e.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound();
            }

            pedido.MetodoPagamento = metodoPagamento;
            _context.Pedido.Update(pedido);
            await _context.SaveChangesAsync();

            if (metodoPagamento == MetodoPagamento.Pix)
            {
                return RedirectToAction(nameof(PagamentoPix), new { pedidoId = pedidoId });
            }
            else if (metodoPagamento == MetodoPagamento.CartaoCredito)
            {
                return RedirectToAction(nameof(PagamentoCartao), new { pedidoId = pedidoId });
            }

            return RedirectToAction(nameof(Checkout), new { pedidoId = pedidoId });
        }

        // GET: Pedidos/PagamentoPix
        public async Task<IActionResult> PagamentoPix(int pedidoId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var pedido = await _context.Pedido
                .Include(e => e.PedidoItens)
                .FirstOrDefaultAsync(e => e.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound();
            }

            double total = pedido.PedidoItens.Sum(e => e.Quantidade * e.Valor);

            var viewModel = new CheckoutViewModel
            {
                PedidoId = pedidoId,
                Total = total,
                MetodoPagamento = MetodoPagamento.Pix
            };

            return View(viewModel);
        }

        // GET: Pedidos/PagamentoCartao
        public async Task<IActionResult> PagamentoCartao(int pedidoId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var pedido = await _context.Pedido
                .Include(e => e.PedidoItens)
                .FirstOrDefaultAsync(e => e.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound();
            }

            double total = pedido.PedidoItens.Sum(e => e.Quantidade * e.Valor);

            var viewModel = new CheckoutViewModel
            {
                PedidoId = pedidoId,
                Total = total,
                MetodoPagamento = MetodoPagamento.CartaoCredito
            };

            return View(viewModel);
        }

        // POST: Pedidos/ConfirmarPagamento
        [HttpPost]
        public async Task<IActionResult> ConfirmarPagamento(int pedidoId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var pedido = await _context.Pedido.FirstOrDefaultAsync(e => e.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound();
            }

            pedido.Status = StatusPagamento.Pago;
            _context.Pedido.Update(pedido);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Success), new { pedidoId = pedidoId });
        }

        // GET: Pedidos/Success
        public async Task<IActionResult> Success(int pedidoId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuarios");
            }

            var pedido = await _context.Pedido
                .Include(e => e.PedidoItens)
                .ThenInclude(e => e.Produto)
                .FirstOrDefaultAsync(e => e.Id == pedidoId);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
    }
}
