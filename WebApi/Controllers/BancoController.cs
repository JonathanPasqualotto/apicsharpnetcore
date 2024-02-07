using Dominio.Interfaces.IBanco;
using Dominio.Interfaces.InterfaceServicos;
using Entidades.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BancoController : ControllerBase
    {
        private readonly InterfaceBanco _infertaceBanco;
        private readonly IBancoServico _interfaceBancoServico;
        public BancoController(InterfaceBanco interfaceBanco, IBancoServico interfaceBancoServico)
        {
            _infertaceBanco = interfaceBanco;
            _interfaceBancoServico = interfaceBancoServico;
        }

        [HttpGet("/api/ListarTodosBancos")]
        [Produces("application/json")]
        public async Task<object> ListarTodosBancos()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _infertaceBanco.ListarTodosBancos();
        }

        [HttpPost("/api/AdicionarBanco")]
        [Produces("application/json")]
        public async Task<object> AdicionarBanco(Banco banco)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            await _interfaceBancoServico.AdicionarBanco(banco);
            return Task.FromResult(banco);
        }

        [HttpPatch("/api/AtualizarBanco")]
        [Produces("application/json")]
        public async Task<object> AtualizarBanco(Banco banco)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _interfaceBancoServico.AtualizarBanco(banco);

            return Task.FromResult(banco);
        }

        [HttpGet("/api/ListarBanco")]
        [Produces("application/json")]
        public async Task<object> ListarBanco(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _infertaceBanco.GetEntityById(id);
        }

        [HttpDelete("/api/DeleteBanco")]
        [Produces("application/json")]
        public async Task<object> DeleteBanco(int id)
        {
            try
            {
                var banco = await _infertaceBanco.GetEntityById(id);
                await _infertaceBanco.Delete(banco);
            }
            catch (Exception ex)
            {

                return Ok("Banco Deletado/Inexistente!");
            }
            return Ok("Banco Deletado!");

        }


    }
}
