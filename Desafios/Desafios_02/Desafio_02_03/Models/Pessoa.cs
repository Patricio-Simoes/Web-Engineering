using Humanizer;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace Desafio_02_03.Models
{
    public class Pessoa
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string morada { get; set; }
        public string cidade { get; set; }
        public string postal { get; set; }

        public Pessoa(int id, string nome, int idade, string morada, string cidade, string postal)
        {
            this.id = id;
            this.nome = nome;
            this.idade = idade;
            this.morada = morada;
            this.cidade = cidade;
            this.postal = postal;
        }
    }
}
