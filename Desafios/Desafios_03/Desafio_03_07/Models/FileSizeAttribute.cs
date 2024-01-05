using System.ComponentModel.DataAnnotations;

namespace Desafio_03_07.Models
{

    public class FileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSize;

        public FileSizeAttribute(long maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}