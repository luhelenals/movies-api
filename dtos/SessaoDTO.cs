using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.dtos
{
    public class SessaoDTO
    {
        public string Filme { get; set; } = "";
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public int SalaId { get; set; }
    }
}