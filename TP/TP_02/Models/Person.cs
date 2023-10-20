using System.ComponentModel.DataAnnotations;

namespace TP_02.Models
{
    public class Person
    {
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Range(18,100,ErrorMessage="{0} must be between {1} and {2}")]
        public int Age { get; set; }
        [Required(ErrorMessage = "The field {0} is mandatory")]
        [DataType(DataType.DateTime)] 
        public DateTime? Date { get; set;}
        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
    }
}
