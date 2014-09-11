using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models
{
    public class Empresa:Pessoa
    {
       // public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("CNPJ")]
        public int Cnpj { get; set; }
    }
}