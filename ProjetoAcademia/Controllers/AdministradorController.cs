using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoAcademia.Models;
using ProjetoAcademia.Repositories;

namespace ProjetoAcademia.Controllers
{
    public class AdministradorController : Controller
    {
        
        public ActionResult Index()
        {
            AdministradorRepository repositorio = new AdministradorRepository();
            return View(repositorio.ObterAdministradores());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdministradorRepository repositorio = new AdministradorRepository();
            Administrador administrador = repositorio.ObterAdministrador(id.Value);

            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                AdministradorRepository repositorio = new AdministradorRepository();
                repositorio.CriarAdministrador(administrador);
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdministradorRepository repositorio = new AdministradorRepository();
            Administrador administrador = repositorio.ObterAdministrador(id.Value);

            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                AdministradorRepository repositorio = new AdministradorRepository();
                repositorio.AtualizarAdministrador(administrador);
                return RedirectToAction("Index");
            }
            return View(administrador);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdministradorRepository repositorio = new AdministradorRepository();
            Administrador administrador = repositorio.ObterAdministrador(id.Value);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdministradorRepository repositorio = new AdministradorRepository();
            repositorio.ExcluirAdministrador(id);
            return RedirectToAction("Index");
        }

    }
}
