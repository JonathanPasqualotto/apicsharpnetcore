using Dominio.Interfaces.IBanco;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class BancoServico : IBancoServico
    {
        private readonly InterfaceBanco _interfaceBanco;

        public BancoServico(InterfaceBanco interfaceBanco) 
        {
            _interfaceBanco = interfaceBanco;
        }

        public async Task AdicionarBanco(Banco banco)
        {
            var valido = banco.ValidarPropriedadeString(banco.NomeBanco, "Nome");
            if (valido)
                await _interfaceBanco.Add(banco);
        }

        public async Task AtualizarBanco(Banco banco)
        {
            var valido = banco.ValidarPropriedadeString(banco.NomeBanco, "Nome");
            if (valido)
                await _interfaceBanco.Update(banco);
        }
    }
}
