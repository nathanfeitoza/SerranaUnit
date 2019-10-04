using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    [DisplayName("Funcionário")]
    public class Funcionario
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Data_Admissao { get; set; }

        public ICollection<Area> Areas { get; set; }
    }
}
