using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace P2_2020CR602.Models
{
    public class covidDbContext : DbContext
    {
        public covidDbContext(DbContextOptions<covidDbContext> options) : base(options)
        {


        }
        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<Generos> generos { get; set; }
        public DbSet<CasosReportados> casosReportados { get; set; }



    }
}
