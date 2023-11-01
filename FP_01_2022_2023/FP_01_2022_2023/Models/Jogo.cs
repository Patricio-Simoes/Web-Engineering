using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FP_01_2022_2023.Models
{
    public class Jogo
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string? nome { get; set; }
        [Required]
        [MaxLength(256, ErrorMessage ="ERRO :: Campo Obrigatório")]
        [Display(Name = "Descrição")]
        public string? descricao { get; set; }
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "ERRO :: Apenas ficheiros .jpg")]
        [Display(Name = "Foto")]
        public string? foto { get; set; }
        [Range(0, 10)]
        [Display(Name = "Pontuação")]
        public int? pontuacao { get; set; } = 0;
        [Display(Name = "Estado")]
        public Boolean estado { get; set; } = true;
    }
}
