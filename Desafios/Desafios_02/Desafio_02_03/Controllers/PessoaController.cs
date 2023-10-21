using Desafio_02_03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace Desafio_02_03.Controllers
{
    public class PessoaController : Controller
    {
        public List<Pessoa> pessoas = new List<Pessoa>();
        public ActionResult Index()
        {
            pessoas = GetPeopleFromDataSource();
            return View(pessoas);
        }

        private List<Pessoa> GetPeopleFromDataSource()
        {
            var people = new List<Pessoa>
            {
                new Pessoa(1, "John Doe", 30, "123 Main St", "New York", "10001" ),
                new Pessoa (2, "Jane Smith", 25, "456 Elm St", "Los Angeles", "90001"),
        };

            return people;
        }

    }
}
