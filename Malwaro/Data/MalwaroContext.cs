using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Malwaro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Malwaro.Data.NovoUsuarioViewModel> NovoUsuarioViewModel { get; set; }



    }
}
