using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Data
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Obrigatório.")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
