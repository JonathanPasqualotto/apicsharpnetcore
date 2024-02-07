using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    public class UsuarioBanco
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage ="E-mail Inválido")]
        [Required(ErrorMessage = "Email Obrigatório")]
        public string Email { get; set; }


        [ForeignKey("Banco")]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Código do Banco Obrigatório")]
        [Range(0, 999.999)]
        public int BancoId { get; set; }

       // public virtual Banco Banco { get; set; }

    }
}
