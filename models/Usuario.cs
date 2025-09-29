using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public Assento[] AssentosReservados { get; set; }
    }
}