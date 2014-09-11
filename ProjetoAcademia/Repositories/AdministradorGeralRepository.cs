using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoAcademia.Models;

namespace ProjetoAcademia.Repositories
{
    public class AdministradorGeralRepository
    {
        public List<AdministradorGeral> ObterAdministradores()
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                return db.Administradores.ToList();
            }

        }

        public AdministradorGeral ObterAdministrador (int Id)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                AdministradorGeral model = db.Administradores.Find(Id);
                return model;
            }

        }

        public List<AdministradorGeral> BuscarAdministrador(string Nome)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                var administradores = db.Administradores.Where(p => p.Nome.Contains(Nome)); 
                return administradores.ToList();
            }

        }

        public AdministradorGeral AtualizarAdministrador(AdministradorGeral administrador)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                db.Entry(administrador).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return administrador;
            }

        }



        public bool Validar(ref AdministradorGeral conta)
        {
            using (MyCompanyContext db = new MyCompanyContext())
            {
                string email = conta.Email;
                string senha = conta.Senha;
                var accounts = db.Administradores.Where(account => account.Email == email && account.Senha == senha);
                if (accounts.Count() > 0)
                {
                    conta = accounts.First();
                    return true;
                }
                else
                    return false;
            }
        }





    }
}