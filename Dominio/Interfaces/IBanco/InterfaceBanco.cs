using Dominio.Interfaces.Generics;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.IBanco
{
    public interface InterfaceBanco : InterfaceGeneric<Banco>
    {
        Task<List<Banco>> ListarBanco(int IdBanco);
        Task<List<Banco>> ListarTodosBancos();

    }
}
