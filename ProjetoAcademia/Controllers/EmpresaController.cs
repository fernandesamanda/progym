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
    public class EmpresaController : Controller
    {

        public ActionResult Index()
        {
            EmpresaRepository repositorio = new EmpresaRepository();
            return View(repositorio.ObterEmpresas());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmpresaRepository repositorio = new EmpresaRepository();
            Empresa empresa = repositorio.ObterEmpresa(id.Value);

            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                EmpresaRepository repositorio = new EmpresaRepository();
                repositorio.CriarEmpresa(empresa);
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmpresaRepository repositorio = new EmpresaRepository();
            Empresa empresa = repositorio.ObterEmpresa(id.Value);

            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                EmpresaRepository repositorio = new EmpresaRepository();
                repositorio.AtualizarEmpresa(empresa);
                return RedirectToAction("Index");
            }
            return View(empresa);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaRepository repositorio = new EmpresaRepository();
            Empresa empresa = repositorio.ObterEmpresa(id.Value);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpresaRepository repositorio = new EmpresaRepository();
            repositorio.ExcluirEmpresa(id);
            return RedirectToAction("Index");
        }

    }
}
