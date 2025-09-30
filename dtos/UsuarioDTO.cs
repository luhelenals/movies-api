using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.dtos
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = "";
        public List<Assento> AssentosReservados { get; set; } = new List<Assento>();
    }
}