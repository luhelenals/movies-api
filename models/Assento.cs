using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Assento
    {
        public int Id { get; set; }

        // add referência para sala
        public int SalaId { get; set; }
        public Sala? Sala { get; set; }

        // reserva x assento -> N:N
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}