using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAcademia.Models
{
    public class Funcionario
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("CPF")]
        public int Cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Data de Admissão")]
        public DateTime DataAdmissao { get; set; }
    }
}