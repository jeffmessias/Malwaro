using Malwaro.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Malwaro.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string Descricao { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Obrigatório.")]
        public double Valor { get; set; }

        [Display(Name = "URL da Imagem")]
        [Required(ErrorMessage = "Obrigatório.")]
        public string ImageURL { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Obrigatório.")]
        public ProdutoCategoria ProdutoCategoria { get; set; }

    }
}
