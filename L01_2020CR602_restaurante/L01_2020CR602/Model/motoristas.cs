using System.ComponentModel.DataAnnotations;
namespace L01_2020CR602.Model
{
    public class Motoristas
    {

        [Key]
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }

    }
}
