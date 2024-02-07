using Dominio.Interfaces.Generics;
using Dominio.Interfaces.InterfaceServicos;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.IUsuarioBanco
{
    public interface InterfaceUsuarioBanco : InterfaceGeneric<UsuarioBanco>
    {
        Task<List<UsuarioBanco>> ListarUsuarioBanco(int IdBanco);

        Task RemoveUsuarios(List<UsuarioBanco> usuarios);

        Task<List<UsuarioBanco>> ListarTodosUsuariosBanco();
    }
}
