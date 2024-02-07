using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entidades.Entidades
{
    public class ApplicationUsers : IdentityUser
    {

        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }

    }
}
