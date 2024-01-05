using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FP_02_2021_2022.Models
{
    public class Livro
    {
        [Key]
        [Required]
        [DisplayName("Título")]
        public string? titulo { get; set; }
        [Required]
        [DisplayName("Autor(es)")]
        public string? autores { get; set; }
        [Required]
        [DisplayName("Editora")]
        public string? editora { get; set; }
        [Required]
        [DisplayName("ISBN-13")]
        [RegularExpression("^(?=(?:\\D*\\d){13}$)\\d{1,5}([- ]?)\\d{1,7}\\1\\d{1,6}\\1\\d$", ErrorMessage = "Apenas ISBN-13")]
        public string? isbn { get; set; }
        [DisplayName("Capa")]
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "ERRO :: Apenas ficheiros .jpg")]
        public string? capa {  get; set; }
        [DisplayName("Contracapa")]
        [RegularExpression(@"^.+\.([jJ][pP][gG])$", ErrorMessage = "ERRO :: Apenas ficheiros .jpg")]
        public string? contracapa { get; set; }
    }
}
