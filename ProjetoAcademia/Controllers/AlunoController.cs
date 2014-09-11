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
    public class AlunoController : Controller
    {

        public ActionResult Index()
        {
            AlunoRepository repositorio = new AlunoRepository();
            return View(repositorio.ObterAlunos());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlunoRepository repositorio = new AlunoRepository();
            Aluno aluno = repositorio.ObterAluno(id.Value);

            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoRepository repositorio = new AlunoRepository();
                repositorio.CriarAluno(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AlunoRepository repositorio = new AlunoRepository();
            Aluno aluno = repositorio.ObterAluno(id.Value);

            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoRepository repositorio = new AlunoRepository();
                repositorio.AtualizarAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunoRepository repositorio = new AlunoRepository();
            Aluno aluno = repositorio.ObterAluno(id.Value);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunoRepository repositorio = new AlunoRepository();
            repositorio.ExcluirAluno(id);
            return RedirectToAction("Index");
        }

    }
}
