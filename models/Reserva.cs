using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; } = DateTime.Now;
        // reserva x assento -> 1:N
        public List<Assento> Assentos { get; set; } = new List<Assento>();
        // reserva x usuário -> N:1
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        // reserva x sessão -> 1:1
        public int SessaoId { get; set; }
        public Sessao? Sessao { get; set; }
    }
}