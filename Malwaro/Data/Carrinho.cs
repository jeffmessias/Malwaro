using Malwaro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Data
{
    public class Carrinho
    {
        public readonly MalwaroContext _context;

        public string Id { get; set; }

        public List<CarrinhoItem> Itens { get; set; }

        public Carrinho(MalwaroContext context)
        {
            _context = context;
        }

        public static Carrinho Get(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context = services.GetService<MalwaroContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoId", carrinhoId);

            return new Carrinho(context) { Id = carrinhoId };
        }

        public List<CarrinhoItem> GetItens()
        {
            return Itens ??= _context.CarrinhoItem
                .Where(e => e.CarrinhoId == this.Id).Include(e => e.Produto).ToList();
        }

        public double GetTotal()
        {
            return _context.CarrinhoItem
                .Where(e => e.CarrinhoId == this.Id).Select(e => e.Produto.Valor * e.Quantidade).Sum();
        }

        public void Add(Produto produto)
        {
            CarrinhoItem item = _context.CarrinhoItem
                .FirstOrDefault(e => e.Produto.Id == produto.Id && e.CarrinhoId == this.Id);

            if (item == null)
            {
                item = new CarrinhoItem()
                {
                    CarrinhoId = this.Id,
                    Produto = produto,
                    Quantidade = 1
                };

                _context.CarrinhoItem.Add(item);

            }
            else
            {
                ++item.Quantidade;
            }

            _context.SaveChanges();
        }

        public async Task ClearAsync()
        {
            List<CarrinhoItem> itens = await _context.CarrinhoItem
                .Where(e => e.CarrinhoId == this.Id).ToListAsync();

            _context.CarrinhoItem.RemoveRange(itens);
            await _context.SaveChangesAsync(); 


        }

        public void Remove(Produto produto)
        {
            CarrinhoItem item = _context.CarrinhoItem
                .FirstOrDefault(e => e.Produto.Id == produto.Id && e.CarrinhoId == this.Id);

            if (item != null)
            {
                if (item.Quantidade > 1)
                {
                    --item.Quantidade;
                }
                else
                {
                    _context.CarrinhoItem.Remove(item);
                }
            }

            _context.SaveChanges();
        }
    }
}
