using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AttAvaliativa.Models;

namespace AtividadeAvaliativa.Controllers
{
    public class ConvidadoController : Controller
    {
        public static IList<Convidado> convidados = new List<Convidado>()
        {
            new Convidado()
            {
                ConvidadoID = 1,
                Nome = "Gabriel",
                EMail = "gabriel@gmail.com",
                Telefone = "3599292929292",
                comparecimento = false
            },
            new Convidado()
            {
                ConvidadoID = 2,
                Nome = "Livia",
                EMail = "Livial@gmail.com",
                Telefone = "3599292929292",
                comparecimento = true
            },
            new Convidado()
            {
                ConvidadoID = 3,
                Nome = "Manoel",
                EMail = "Monoel@gmail.com",
                Telefone = "3599296629292",
                comparecimento = true
            },
            new Convidado()
            {
                ConvidadoID = 4,
                Nome = "Lucas",
                EMail = "lcas@gmail.com",
                Telefone = "359924342929292",
                comparecimento = false
            }
        };

        public IActionResult Index()
        {
            return View(convidados.OrderBy(cov => cov.ConvidadoID));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Convidado convidado)
        {
            convidados.Add(convidado);
            convidado.ConvidadoID = convidados.Select(cov => cov.ConvidadoID).Max() + 1;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            return View(convidados.Where(cat => cat.ConvidadoID == id).First());
        }
        public IActionResult Edit(int id)
        {
            return View(convidados.Where(cov => cov.ConvidadoID == id).First());
        }
        [HttpPost]
        public IActionResult Edit(Convidado convidado)
        {
            convidados.Remove(convidados.Where(cov => cov.ConvidadoID == convidado.ConvidadoID).First());
            convidados.Add(convidado);
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            return View(convidados.Where(cov => cov.ConvidadoID == id).First());
        }
        public IActionResult Delete(Convidado convidado)
        {
            convidados.Remove(convidados.Where(cov => cov.ConvidadoID == convidado.ConvidadoID).First());
            return RedirectToAction("Index");

        }

    }
}