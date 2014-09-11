using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoAcademia.Models;
using ProjetoAcademia.Repositories;

namespace ProjetoAcademia.Controllers
{
    public class AdministradorGeralController : Controller
    {
        public ActionResult Index ()
        {

            AdministradorGeralRepository repository = new AdministradorGeralRepository();
            return View(repository.ObterAdministradores());

        }
       
        public ActionResult Detalhes(int Id)
        {
            AdministradorGeralRepository repository = new AdministradorGeralRepository();
            return View(repository.ObterAdministrador(Id));
     
        }

        public ActionResult Pesquisa(string Nome)
        {
            AdministradorGeralRepository repository = new AdministradorGeralRepository();
            return View("Index", repository.BuscarAdministrador(Nome));

        }

        public ActionResult Editar(int Id)
        {
            AdministradorGeralRepository repository = new AdministradorGeralRepository();
            AdministradorGeral administrador = repository.ObterAdministrador(Id);
            return View(administrador);

        }

        [HttpPost]
        public ActionResult Editar(AdministradorGeral administrador)
        {
            if (ModelState.IsValid)
            {
                AdministradorGeralRepository repository = new AdministradorGeralRepository();
                repository.AtualizarAdministrador(administrador);
                return RedirectToAction("Index");

            }
            else
                return View(administrador);            
        }
	}
}