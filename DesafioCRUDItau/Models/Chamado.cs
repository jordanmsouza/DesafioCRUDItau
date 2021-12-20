using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCRUDItau.Models
{
    public class Chamado
    {
        public int Id { get; set; }

        [Display(Name = "Gravidade")]
        public int GravidadeId { get; set; }
        public Gravidade Gravidade { get; set; }

        [Display(Name = "Tipo de Solicitação")]
        public int TipoSolicitacaoId { get; set; }
        [Display(Name = "Tipo de Solicitação")]
        public TipoSolicitacao TipoSolicitacao { get; set; }

        public string Assunto { get; set; }
        public string Menssagem { get; set; }

        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        [Display(Name = "Usuário")]
        public Usuario Usuario { get; set; }
    }
}
