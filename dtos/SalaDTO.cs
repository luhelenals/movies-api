using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace movies_api.dtos
{
    public class SalaDTO
    {
        public string Nome { get; set; } = "";
        public int Capacidade { get; set; }
        public List<int> Assentos { get; set; } = new List<int>();
        public List<int> Sessoes { get; set; } = new List<int>();
    }
}