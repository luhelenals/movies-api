using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Assento
    {
        public int Id { get; set; }
        public bool Disponivel { get; set; } = true; // default = true

        // add fk da sessão
        public int SessaoId { get; set; }
        public Sessao Sessao { get; set; }

        // add fk do usuário
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}