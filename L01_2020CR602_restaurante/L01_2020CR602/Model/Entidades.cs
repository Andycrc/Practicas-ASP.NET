using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01_2020CR602.Model

{
    public class Entidades : DbContext
    {
        public Entidades(DbContextOptions<Entidades> options) : base(options)
        {

        }

        public DbSet<Pedidos> pedidos { get; set; }
        public DbSet<Platos> platos { get; set; }
        public DbSet<Motoristas> motoristas { get; set; }
        public DbSet<clientes> clientes { get; set; }

    }
}
