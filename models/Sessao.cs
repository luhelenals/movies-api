using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Sessao
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public String Filme { get; set; }
        public Assento[] Assentos { get; set; }
    }
}