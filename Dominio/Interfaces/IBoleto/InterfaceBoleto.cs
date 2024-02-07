using Dominio.Interfaces.Generics;
using Entidades.Entidades;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.IBoleto
{
    public interface InterfaceBoleto : InterfaceGeneric<Boleto>
    {
        Task<List<Boleto>> ListarBoleto(int IdBoleto);
        Task<List<Boleto>> ListarTodosBoletos();
    }
}
