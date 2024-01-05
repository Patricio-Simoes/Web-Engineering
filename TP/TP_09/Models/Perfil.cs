using System.ComponentModel.DataAnnotations;

namespace TP_09.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string? UserName { get; set; }
    }
}
