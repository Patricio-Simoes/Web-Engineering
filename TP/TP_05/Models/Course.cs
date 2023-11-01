﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_05.Models
{
    public class Course
    {
        [Required(ErrorMessage ="Reequired Field")]
        [StringLength(50,MinimumLength = 3, ErrorMessage ="{0} must be between {2} and {1}")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Required Field!")]
        [StringLength(256, ErrorMessage ="Length can not exceed {1} characters")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Credits { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName="money")]
        public decimal Cost { get; set; }
        public Boolean State {  get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}