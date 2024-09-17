using P2_2020CR602.Models;
using System.ComponentModel.DataAnnotations;

namespace P2_2020CR602.Models
{
    public class CasosReportados
    {
        [Key]
        public int id_caso_reportado { get; set; }
        public int id_departamento { get; set; }   
        public int id_genero { get; set; }   
        public int casos_confirmados { get; set; }
        public int recuperados { get; set; }
        public int fallecidos { get; set; }


    }
}
