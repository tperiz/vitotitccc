using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccVitoti.Entities
{
    public class Criterio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Peso { get; set; }
        public string Funcao { get; set; }
        public List<Alternativa> Alternativas { get; set; }
    }
}
