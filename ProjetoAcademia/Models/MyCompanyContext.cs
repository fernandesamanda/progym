using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjetoAcademia.Models
{
    public class MyCompanyContext:DbContext
    {
        public DbSet<AdministradorGeral> Administradores { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
    }
}