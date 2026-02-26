using Malwaro.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Models
{
    public class Usuario:IdentityUser
    {
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
        public DateTime DataNascimento { get; set; }

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
