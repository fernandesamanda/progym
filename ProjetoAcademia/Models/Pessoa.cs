using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoAcademia.Models
{
    public abstract class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.PostalCode)]
        public int Cep { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.PhoneNumber)]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Campo senha é requerido")]
        public string Senha { get; set; }

        
        [DisplayName("Data de Cadastro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }
    }
}