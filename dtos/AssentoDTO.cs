using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.dtos
{
    public class AssentoDTO
    {
        public int? UsuarioId { get; set; }
        public int SessaoId { get; set; }
        public bool Disponivel { get; set; } = true;
    }
}