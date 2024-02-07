using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    [Table("Boleto")]
    public class Boleto : Base
    {

        [Required(ErrorMessage = "Nome Pagador Obrigatório")]
        public string NomePagador { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ Obrigatório")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "O Número esta incorreto")]
        public string CpfCnpjPagador { get; set; }

        [Required(ErrorMessage = "Nome Beneficiario Obrigatório")]
        public string NomeBeneficiario { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ Obrigatório")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "O Número esta incorreto")]
        public string CpfCnpjBeneficiario { get; set; }

        [Required(ErrorMessage = "Valor Obrigatório")]
        public decimal Valor {  get; set; }

        [Required(ErrorMessage = "Data Vencimento Obrigatório")]
        public DateTime DataVencimento { get; set; }

        public string Observacao { get; set; }

        [ForeignKey("Banco")]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Id do Banco Obrigatório")]
        [Range(1,999.99,ErrorMessage ="Id do Banco Obrigatório")]
        public int BancoId { get; set; }
       // public virtual Banco Banco { get; set; }
    }


}
