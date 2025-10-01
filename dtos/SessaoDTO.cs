using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movies_api.models;

namespace movies_api.dtos
{
    public class SessaoDTO
    {
        public int? Id { get; set; }
        public DateTime Horario { get; set; }
        public string Filme { get; set; } = "";
        public List<Assento> Assentos { get; set; } = new List<Assento>();
    }
}