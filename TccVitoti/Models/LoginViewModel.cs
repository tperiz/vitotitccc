using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccVitoti.Models
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string Nome { set; get; }

        public string Mensagem { set; get; }
    }
}
