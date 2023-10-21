using System.ComponentModel.DataAnnotations;

namespace Desafio_02_05.Models
{
    public class Trip
    {
        [Required(ErrorMessage = "ERROR :: This field is mandatory!")]
        public string? location { get; set; }
        [Required(ErrorMessage = "ERROR :: This field is mandatory!")]
        [DataType(DataType.DateTime)]
        public DateTime? departureDate { get; set; }
        [Required(ErrorMessage = "ERROR :: This field is mandatory!")]
        [DataType(DataType.DateTime)]
        [Compare("departureDate", ErrorMessage = "Arrival Date must be later than Departure Date")]
        public DateTime? arrivalDate { get; set; }

        [Required(ErrorMessage = "ERROR :: This field is mandatory!")]
        public double? distance { get; set; }
    }
}
