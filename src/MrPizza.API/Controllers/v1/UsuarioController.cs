using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Commands.Usuario;

namespace MrPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] NewUsuarioCommand command)
        {
            try
            {
                var result = await _mediator.Send(
                new NewUsuarioCommand(
                    command.Nome,
                    command.Login,
                    command.Senha,
                    command.ConfirmarSenha,
                    command.Enderecos,
                    command.DDD,
                    command.Telefone)
                );
                if (result.Ok)
                    return Ok();
                return BadRequest(result.Errors);
            }
            catch
            {
                //logar erro em algum lugar
                return StatusCode(500);
            }
        }
    }
}
