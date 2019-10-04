using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class Cultura
    {
        public int Cultura_Id { get; set; }
        public string Nome { get; set; }
        public int Mes_Inicio { get; set; }
        public int Mes_Fim { get; set; }
        public string Data_Inicio { get; set; }
        public string TempoMaximo { get; set; }

        public ICollection<Area> Areas { get; set; }
        public ICollection<Ataque> Ataques { get; set; }
    }
}
