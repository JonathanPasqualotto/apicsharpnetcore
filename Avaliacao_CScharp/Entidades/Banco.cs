using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("Banco")]
    public class Banco : Base
    {
        [Required(ErrorMessage ="Nome do Banco Obrigatório")]
        public string NomeBanco { get; set; }
        [Required(ErrorMessage = "Código do Banco Obrigatório")]
        public int CodigoBanco { get; set; }
        [Required(ErrorMessage = "Percentual de Juros é Obrigatório")]
        [Range(0,1000)]
        public decimal PercentualJuros { get; set; }

    }
}
