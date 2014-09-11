using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAcademia.Models
{
    public class Administrador:Pessoa
    {
        //[Key]
        //public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("CPF")]
        public int Cpf { get; set; }
    }
}