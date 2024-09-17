using Microsoft.EntityFrameworkCore;
using L01P02_2020CR602.Models;

namespace L01P02_2020CR602.Models
{
    public class restauranteDbContext : DbContext
    {
        public restauranteDbContext(DbContextOptions<restauranteDbContext> options) : base(options)
        {


        }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<L01P02_2020CR602.Models.clientes>? clientes { get; set; }
        public DbSet<L01P02_2020CR602.Models.platos>? platos { get; set; }
        public DbSet<L01P02_2020CR602.Models.motoristas>? motoristas { get; set; }


    }
}
