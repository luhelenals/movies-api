using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.dtos
{
    public class UsuarioDTO
    {
        public string Nome { get; set; } = "";
        public List<Reserva>? Reservas { get; set; } = new List<Reserva>();
    }
}