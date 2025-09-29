using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public List<Assento> AssentosReservados { get; set; } = new List<Assento>();
    }
}