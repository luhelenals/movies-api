using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.dtos
{
    public class ReservaDTO
    {
        public List<Assento> Assentos { get; set; } = [];
        public int UsuarioId { get; set; }
        public int SessaoId { get; set; }
    }
}