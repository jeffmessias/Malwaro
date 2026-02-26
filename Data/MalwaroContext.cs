using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Malwaro.Models;
using Malwaro.Data;

namespace Malwaro.Data
{
    public class MalwaroContext : IdentityDbContext<Usuario>
    {
        public MalwaroContext (DbContextOptions<MalwaroContext> options)
            : base(options)
        {
        }
        public DbSet<Malwaro.Models.Produto> Produto { get; set; }
        public DbSet<Malwaro.Models.Pedido> Pedido { get; set; }
        public DbSet<Malwaro.Models.PedidoItem> PedidoItem { get; set; }
        public DbSet<Malwaro.Models.CarrinhoItem> CarrinhoItem { get; set; }
        // ViewModels não devem ser mapeados como entidades do banco de dados



    }
}
