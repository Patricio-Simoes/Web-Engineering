using System.ComponentModel.DataAnnotations;

namespace Desafio_02_02.Models
{
    public class User
    {
        [Required(ErrorMessage = "ERRO :: Este campo é necessário!")]
        public string username { get; set; }
        [Required(ErrorMessage = "ERRO :: Este campo é necessário!")]
        [RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$",
        ErrorMessage = "ERRO :: Este endereço não é válido!")]
        public string email { get; set; }
        public bool terms { get; set; }
    }
}
