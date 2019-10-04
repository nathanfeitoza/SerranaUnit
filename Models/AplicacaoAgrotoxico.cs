using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class AplicacaoAgrotoxico
    {
        public int Qtd_Aplicada { get; set; }
        public string Tipo { get; set; }
        public int Area_Id { get; set; }
        public Area Area { get; set; }
        public int Agro_Id { get; set; }
        public Agrotoxico Agrotoxico { get; set; }
    }
}
