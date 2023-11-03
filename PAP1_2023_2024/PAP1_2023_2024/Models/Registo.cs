using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PAP1_2023_2024.Models
{
    public class Registo
    {
        // A key já garante o valor único.
        [Key]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Username")]
        public string? username { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.DateTime)]
        [DisplayName("Entrada")]
        public DateTime entrada { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Saída")]
        public DateTime? saida { get; set; }
    }
}
