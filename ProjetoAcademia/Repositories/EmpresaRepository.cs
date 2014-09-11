using ProjetoAcademia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcademia.Repositories
{
    public class EmpresaRepository
    {
        public List<Empresa> ObterEmpresas()
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                return db.Empresa.ToList();
            }
        }

        public Empresa ObterEmpresa(int id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {

                var empresaes = db.Empresa;
                Empresa empresa = empresaes.First();
                return empresa;
            }
        }

        public Empresa AtualizarEmpresa(Empresa empresa)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return empresa;
            }
        }

        public Empresa CriarEmpresa(Empresa empresa)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return empresa;
            }

        }

        public void ExcluirEmpresa(int id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                Empresa empresa = db.Empresa.Find(id);
                db.Empresa.Remove(empresa);
                db.SaveChanges();
            }
        }
    }
}