using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FP_01_2021_2022.Models
{
    public class Contacto
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required(ErrorMessage = "E-mail obrigatório")]
        [DisplayName("E-mail")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        [DisplayName("Nome")]
        public string? name { get; set; }
        [Required(ErrorMessage = "Nickname obrigatório")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo: {0}")]
        [RegularExpression("^[a-zA-ZÀ-ÖØ-öø-ÿ]+$", ErrorMessage = "Apenas uma palavra")]
        [DisplayName("Nickname")]
        public string? nickname { get; set; }
        [DisplayName("Amigo")]
        public bool amigo { get; set; } = false;
    }
}
