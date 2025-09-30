using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.dtos
{
    public class SessaoDTO
    {
        public DateTime Horario { get; set; }
        public string Filme { get; set; } = "";
        public List<Assento> Assentos { get; set; } = new List<Assento>();
    }
}