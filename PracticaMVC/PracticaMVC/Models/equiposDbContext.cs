using Microsoft.EntityFrameworkCore;

namespace PracticaMVC.Models
{
    public class equiposDbContext : DbContext
    {

        public equiposDbContext(DbContextOptions<equiposDbContext> options) : base(options)
        {


        }
        public DbSet<marcas> marcas { get; set; }   
    }
}
