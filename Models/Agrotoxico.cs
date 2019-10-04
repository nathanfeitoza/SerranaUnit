using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Serrana.Models
{
    public class Agrotoxico
    {
        [Key]
        public int Agro_Id { get; set; }
        public string Nome { get; set; }
        public int Qtd_Disponivel { get; set; }
        public string Unidade_Medida { get; set; }

        public ICollection<Combate> Combates { get; set; }
        public ICollection<AplicacaoAgrotoxico> AplicacoesAgrotoxicos { get; set; }
    }
}
