using System.ComponentModel.DataAnnotations;

namespace P2_2020CR602.Models
{
    public class Generos
    {
        [Key]
        public int id_genero { get; set; }
        public string nombre_genero { get; set; }
    }
}
