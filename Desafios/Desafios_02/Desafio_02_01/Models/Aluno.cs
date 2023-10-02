﻿using System.ComponentModel.DataAnnotations;

namespace Desafio_02_01.Models
{
    public class Aluno
    {
        [Required(ErrorMessage = "ERRO :: Insira um número válido!")]
        [RegularExpression("[1-9][1-9]*", ErrorMessage = "ERRO :: Apenas valores numéricos são válidos!")]
        public string numero { get; set; }
        [Required(ErrorMessage = "ERRO :: Insira um nome válido")]
        [RegularExpression("[a-zA-Z][a-zA-Z]*", ErrorMessage = "ERRO :: Valores numéricos não são válidos!")]
        public string nome { get; set; }
    }
}
