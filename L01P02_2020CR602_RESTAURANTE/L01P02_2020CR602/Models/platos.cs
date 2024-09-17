using System.ComponentModel.DataAnnotations;
namespace L01P02_2020CR602.Models
{
    public class platos
    {
        [Key]
        public int platoId { get; set; }
        [Display(Name = "Nombre del plato")]
        public string nombrePlato { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
    }
}
