using Dominio.Interfaces.IBanco;
using Dominio.Interfaces.IBoleto;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoletoController : ControllerBase
    {
        private readonly InterfaceBoleto _interfaceBoleto;
        private readonly IBoletoServico _interfaceBoletoServico;
        private readonly InterfaceBanco _interfaceBanco;


        public BoletoController(InterfaceBoleto interfaceBoleto, IBoletoServico interfaceBoletoServico, InterfaceBanco interfaceBanco)
        {
            _interfaceBoleto = interfaceBoleto;
            _interfaceBoletoServico = interfaceBoletoServico;
            _interfaceBanco = interfaceBanco;
        }

        [HttpGet("/api/ListarBoleto")]
        [Produces("application/json")]

        public async Task<object> ListarBoleto( int IdBoleto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var boleto = await _interfaceBoleto.GetEntityById(IdBoleto);

            if (boleto == null)
            {
                return Ok("Boleto não encontrado");
            }

            if (boleto.DataVencimento < DateTime.Now)
            {
                // Obtém o percentual de juros associado ao IdBoleto
                var juros = await _interfaceBanco.ListarBanco(boleto.BancoId);

                decimal valorBoleto = boleto.Valor;
                decimal percentualJuros = juros.ToList().Sum(x => x.PercentualJuros);
                decimal tot = valorBoleto * (percentualJuros / 100);

                return new
                {
                    nomePagador = boleto.NomePagador,
                    cpfCnpjPagador = boleto.CpfCnpjPagador,
                    nomeBeneficiario = boleto.NomeBeneficiario,
                    cpfCnpjBeneficiario = boleto.CpfCnpjBeneficiario,
                    dataVencimento =  boleto.DataVencimento,
                    observacao = boleto.Observacao,
                    bancoId = boleto.BancoId,
                    id = boleto.Id,
                    valor = boleto.Valor,
                    PercentualJurosAplicado = percentualJuros,
                    TotalComJuros = tot
                };

            }
            else
            {
                return await _interfaceBoleto.GetEntityById(IdBoleto);
            }
        }

        [HttpPost("/api/AdicionarBoleto")]
        [Produces("application/json")]

        public async Task<object> AdicionarBoleto(Boleto boleto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            await _interfaceBoletoServico.AdicionarBoleto(boleto);
            return boleto;
        }

        [HttpPatch("/api/AtualizarBoleto")]
        [Produces("application/json")]

        public async Task<object> AtualizarBoleto(Boleto boleto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _interfaceBoletoServico.AtualizarBoleto(boleto);
            return boleto;
        }

        [HttpDelete("/api/DeleteBoleto")]
        [Produces("application/json")]

        public async Task<object> DeleteBoleto(int IdBoleto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var boleto = await _interfaceBoleto.GetEntityById(IdBoleto);
                await _interfaceBoleto.Delete(boleto);
            }
            catch (Exception ex)
            {

                return Ok("Boleto Deletado/Inexistente!");
            }
            return Ok("Boleto deletado!");

        }

        [HttpGet("/api/ListarTodosBoletos")]
        [Produces("application/json")]

        public async Task<object> ListarTodosBoletos()
        {
            return await _interfaceBoleto.ListarTodosBoletos();
        }


    }
}
