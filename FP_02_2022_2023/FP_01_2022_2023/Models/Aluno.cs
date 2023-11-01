using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FP_01_2022_2023.Models
{
    public class Aluno
    {
        [Key]
        [Required(ErrorMessage = "Número Obrigatório")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Número")]
        public int numero {  get; set; }
        [Required(ErrorMessage = "E-mail Obrigatório")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Nome Obrigatório")]
        [DisplayName("Nome")]
        public string? nome { get; set; }
        [Required(ErrorMessage = "Data de Nascimento Obrigatória")]
        [DataType(DataType.Date)]
        [DisplayName("Idade")]
        public DateTime date { get; set; }
    }
}
