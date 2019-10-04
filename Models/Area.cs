using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class Area
    {
        public int Area_Id { get; set; }
        public float Tamanho { get; set; }
        public StatusEnum Status { get; set; }
        public int Cultura_Id { get; set; }
        public Cultura Cultura { get; set; }
        public int Maticula_Funcionario { get; set; }
        public Funcionario Funcionario { get; set; }

        public ICollection<AplicacaoAgrotoxico> AplicacoesAgrotoxicos { get; set; }
    }
}
