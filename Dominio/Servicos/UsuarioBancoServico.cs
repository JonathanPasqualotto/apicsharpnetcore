using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.IUsuarioBanco;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class UsuarioBancoServico : IUsuarioBanco
    {
        private readonly InterfaceUsuarioBanco _interfaceUsuarioBanco;

        public UsuarioBancoServico(InterfaceUsuarioBanco interfaceUsuarioBanco)
        {
            _interfaceUsuarioBanco = interfaceUsuarioBanco;
        }

        public async Task AdicionarUsuarioBanco(UsuarioBanco usuarioBanco)
        {
            await _interfaceUsuarioBanco.Add(usuarioBanco);
        }
    }
}
