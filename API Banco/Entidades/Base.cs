using Entidades;
using Entities.Notificacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades
{
    public class Base : Notifica
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
    }
}
