using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Sessao
    {
        public int Id { get; set; }
        public string Filme { get; set; } = "";
        // horários de início e fim
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        // sessão x sala -> N:1
        public int SalaId { get; set; }
        public Sala? Sala { get; set; }
    }
}