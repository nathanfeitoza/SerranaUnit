using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class Ataque
    {
        public int Cultura_Id { get; set; }
        public Cultura Cultura { get; set; }
        public int Praga_Id { get; set; }
        public Praga Praga { get; set; }
    }
}
