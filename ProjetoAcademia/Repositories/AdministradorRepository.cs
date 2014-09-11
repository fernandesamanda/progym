using ProjetoAcademia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcademia.Repositories
{
    public class AdministradorRepository
    {
        public List<Administrador> ObterAdministradores()
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                return db.Administrador.ToList();
            }
        }

        public Administrador ObterAdministrador(int id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                Administrador model = db.Administrador.Find(id);
                return model;
            }
        }

        public Administrador AtualizarAdministrador(Administrador administrador)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Entry(administrador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return administrador;
            }
        }

        public Administrador CriarAdministrador(Administrador administrador)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Administrador.Add(administrador);
                db.SaveChanges();
                return administrador;
            }

        }

        public void ExcluirAdministrador(int id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                Administrador administrador = db.Administrador.Find(id);
                db.Administrador.Remove(administrador);
                db.SaveChanges();
            }
        }
    }
}