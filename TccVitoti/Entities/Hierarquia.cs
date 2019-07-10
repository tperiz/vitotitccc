using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccVitoti.Entities
{
    public class Hierarquia
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Criterio> Criterios { get; set; }
    }
}
