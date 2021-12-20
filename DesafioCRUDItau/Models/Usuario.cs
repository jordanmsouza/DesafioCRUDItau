using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCRUDItau.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório!!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo cep é obrigatório!!")]
        public string Cep { get; set; }
        public string Endereco { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        [Display(Name = "UF")]
        public string Uf { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido!")]
        public string Email { get; set; }
    }
}

