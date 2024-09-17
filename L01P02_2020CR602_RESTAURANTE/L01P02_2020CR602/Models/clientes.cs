using System.ComponentModel.DataAnnotations;

namespace L01P02_2020CR602.Models
{
    public class clientes
    {
        [Key]

        
        public int clienteId { get; set; }
        [Display(Name = "Nombre del cliente")]
        public string nombreCliente { get; set; }

        [Display(Name = "Direccion del cliente")]
        public string direccion { get; set; }

    }
}
