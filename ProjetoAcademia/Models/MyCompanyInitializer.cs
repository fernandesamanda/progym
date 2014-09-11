using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAcademia.Models
{
    public class MyCompanyInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<MyCompanyContext>
    {
        protected override void Seed(MyCompanyContext context)
        {
            var administradores = new List<AdministradorGeral>
            {
                new AdministradorGeral {
                    Id = 1,
                    Cpf = 123,
                    Nome = "Amanda",
                    Endereco = "Rua das Flores",
                    Numero = 123,
                    Bairro = "Das Rosas",
                    Cep = 12700000,
                    Email = "amanda@teste.com",
                    Senha=ProjetoAcademia.Controllers.AccountController.Encrypt("123"),
                    Telefone = 3145-1234,
                    DataCadastro = DateTime.Today
                },
            };

            administradores.ForEach(s => context.Administradores.Add(s));
            context.SaveChanges();

            var administrador = new List<Administrador>
            {
                new Administrador {
                    Id = 1,
                    Cpf = 123,
                    Nome = "Academia Saude",
                    Endereco = "Rua das Flores",
                    Numero = 123,
                    Bairro = "Das Rosas",
                    Cep = 12700000,
                    Email = "amanda@teste.com",
                    Senha = ProjetoAcademia.Controllers.AccountController.Encrypt("123"),
                    Telefone = 3145-1234,
                    DataCadastro = DateTime.Today
                },
            };

            administrador.ForEach(s => context.Administrador.Add(s));
            context.SaveChanges();
        }
    }
}