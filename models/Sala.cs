using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public int Capacidade { get; set; }
        public List<Assento> Assentos { get; set; } = [];
        public List<Sessao> Sessoes { get; set; } = [];
    }
}