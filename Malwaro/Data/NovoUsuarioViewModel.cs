using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Data
{
    public class NovoUsuarioViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string Sobrenome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string CPF { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Obrigatório.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        [Display(Name = "Confirmar Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas devem ser idênticas.")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string EnderecoRua { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string EnderecoBairro { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string EnderecoCidade { get; set; }

        [Display(Name = "UF")]
        [Required(ErrorMessage = "Obrigatório.")]
        public UsuarioEnderecoUF EnderecoUF { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string EnderecoCEP { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "Obrigatório.")]
        public int EnderecoNumero { get; set; }

        [Display(Name = "Complemento")]
        public string EnderecoComplemento { get; set; }
    }
}
