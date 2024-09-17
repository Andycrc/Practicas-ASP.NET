using System.ComponentModel.DataAnnotations;
namespace L01P02_2020CR602.Models
{
    public class motoristas
    {
        [Key]
        public int motoristaId { get; set; }

        [Display(Name = "Nombre del motorista")]
        public string nombreMotorista { get; set; }
    }
}
