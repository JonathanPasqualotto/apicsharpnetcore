using Dominio.Interfaces.IBanco;
using Dominio.Interfaces.IBoleto;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicos
{
    public class BoletoServico : IBoletoServico
    {
        private readonly InterfaceBoleto _interfaceBoleto;
        private readonly InterfaceBanco _interfaceBanco;

        public BoletoServico(InterfaceBoleto interfaceBoleto, InterfaceBanco interfaceBanco) 
        {
            _interfaceBoleto = interfaceBoleto;
            _interfaceBanco = interfaceBanco;
        }

        public async Task AdicionarBoleto(Boleto boleto)
        {
            var valido = boleto.ValidarPropriedadeString(boleto.NomePagador, "Nome");
            if (valido)
                await _interfaceBoleto.Add(boleto);
        }

        public async Task AtualizarBoleto(Boleto boleto)
        {
            var valido = boleto.ValidarPropriedadeString(boleto.NomePagador, "Nome");
            if (valido)
                await _interfaceBoleto.Update(boleto);
        }


    }
}
