using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class Praga
    {
        public int Praga_Id { get; set; }
        public string Nome_Popular { get; set; }
        public string Nome_Cientifico { get; set; }
        public string Estacao { get; set; }

        public ICollection<Combate> Combates { get; set; }
        public ICollection<Ataque> Ataques { get; set; }
    }
}
