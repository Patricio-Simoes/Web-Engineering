using System.ComponentModel.DataAnnotations;

namespace Desafio_03_07.Models
{
    public class Document
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [FileSize(400 * 1024 * 1024, ErrorMessage = "The file size cannot exceed 400 MB.")]
        public string description { get; set; }
    }
}
