using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FP_02_01_2022_2023.Models
{
    public class BolsaInvestigacao
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [DisplayName("Título")]
        public string? titulo { get; set; }
        [Required]
        [DisplayName("Área Científica")]
        public string? area { get; set; }
        [Required]
        [DisplayName("Duração")]
        public int duracao { get; set; }
        [Required]
        [DisplayName("Remuneração")]
        public int remuneracao { get; set; }
    }
}
