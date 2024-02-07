using Entidades.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;

        public UserController(UserManager<ApplicationUsers> userManager,
            SignInManager<ApplicationUsers> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/AdicionarUsuario")]

        public async Task<ActionResult> AdicionarUsuario([FromBody] Login login)
        {
            if (string.IsNullOrWhiteSpace(login.email) ||
                string.IsNullOrWhiteSpace(login.senha) ||
                string.IsNullOrWhiteSpace(login.cpfCnpj))
            {
                return Ok("Falta alguns dados");
            }

            var user = new ApplicationUsers
            {
                Email = login.email,
                UserName = login.email,
                CpfCnpj = login.cpfCnpj
            };

            var result = await _userManager.CreateAsync(user,login.senha); 
            if (result.Errors.Any())
            {
                return Ok(result.Errors);
            }

            // Geração de confirmação caso precise

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            // retorno do email

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var response_Retorn = await _userManager.ConfirmEmailAsync(user, code);

            if (response_Retorn.Succeeded)
            {
                return Ok("Usuário adicionado!");
            }
            else
            {
                return Ok("Erro ao confirmar cadastro de usuário!");
            }


        }






    }
}
