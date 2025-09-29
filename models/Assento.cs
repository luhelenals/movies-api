using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Assento
    {
        public int Id { get; set; }
        public bool Disponivel { get; set; }
        public Sessao Sessao { get; set; }
    }
}