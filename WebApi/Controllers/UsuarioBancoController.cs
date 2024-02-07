using Dominio.Interfaces.InterfaceServicos;
using Dominio.Interfaces.IUsuarioBanco;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioBancoController : ControllerBase
    {
        private readonly InterfaceUsuarioBanco _interfaceUsuarioBanco;
        private readonly IUsuarioBanco _IUsuarioBanco;

        public UsuarioBancoController(InterfaceUsuarioBanco interfaceUsuarioBanco, IUsuarioBanco iUsuarioBanco)
        {
            _interfaceUsuarioBanco = interfaceUsuarioBanco;
            _IUsuarioBanco = iUsuarioBanco;
        }

        [HttpGet("api/ListarUsuarioBanco")]
        [Produces("application/json")]
        public async Task<object> ListarUsuarioBanco( int IdBanco)
        {
            return await _interfaceUsuarioBanco.ListarUsuarioBanco(IdBanco);

        }

        [HttpPost("api/AdicionarUsuarioBanco")]
        [Produces("application/json")]
        public async Task<object> AdicionarUsuarioBanco(int IdBanco, string emailUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _IUsuarioBanco.AdicionarUsuarioBanco(
                    new UsuarioBanco
                    {
                        BancoId = IdBanco,
                        Email = emailUsuario
                    });
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }
            return Ok("Usuario Adicionado");
        }

        [HttpDelete("api/DeleteUsuarioBanco")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioBanco(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var usuariobanco = await _interfaceUsuarioBanco.GetEntityById(Id);

                await _interfaceUsuarioBanco.Delete(usuariobanco);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }
            return Ok("Usuario Deletado");
        }

        [HttpGet("api/ListarTodosUsuariosBanco")]
        [Produces("application/json")]
        public async Task<object> ListarTodosUsuariosBanco()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return await _interfaceUsuarioBanco.ListarTodosUsuariosBanco();
        }

    }
}
