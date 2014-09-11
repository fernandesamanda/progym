using ProjetoAcademia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcademia.Repositories
{
    public class AlunoRepository
    {
        public List<Aluno> ObterAlunos()
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                return db.Aluno.ToList();
            }
        }

        public Aluno ObterAluno(int id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {

                var alunoes = db.Aluno;
                Aluno aluno = alunoes.First();
                return aluno;
            }
        }

        public Aluno AtualizarAluno(Aluno aluno)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return aluno;
            }
        }

        public Aluno CriarAluno(Aluno aluno)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
                return aluno;
            }

        }

        public void ExcluirAluno(int id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                Aluno aluno = db.Aluno.Find(id);
                db.Aluno.Remove(aluno);
                db.SaveChanges();
            }
        }
    }
}