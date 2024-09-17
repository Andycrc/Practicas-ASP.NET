using System.ComponentModel.DataAnnotations;

namespace P2_2020CR602.Models
{
    public class Departamentos
    {
        [Key]
        public int id_departamento { get; set; }
        public string nombre_departamento { get; set; }
    }
}
