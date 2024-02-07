using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IUsuarioBanco
    {
        Task AdicionarUsuarioBanco(UsuarioBanco usuarioBanco);

    }
}
