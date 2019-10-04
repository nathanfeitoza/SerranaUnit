using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class Combate
    {
        public int Praga_Id { get; set; }
        public Praga Praga { get; set; }
        public int Agro_Id { get; set; }
        public Agrotoxico Agrotoxico { get; set; }
    }
}
