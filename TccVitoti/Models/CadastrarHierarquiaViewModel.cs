using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccVitoti.Models
{
    public class CadastrarHierarquiaViewModel
    {
        public string HierarquiaNome { get; set; }
        public string HierarquiaDescricao { get; set; }
        public int QtdAlternativa { get; set; }
        public List<string> NomeCriteriosAdicionados { get; set; } = new List<string>();
        public List<int> PesoCriteriosAdicionados { get; set; } = new List<int>();
        public List<string> FuncaoCriteriosAdicionados { get; set; } = new List<string>();
        public int QtdCriterio{ get; set; }

    }
}
