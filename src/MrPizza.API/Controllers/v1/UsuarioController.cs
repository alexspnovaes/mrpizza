using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Commands.Usuario;
using MrPizza.Domain.Models.Inputs;

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
        public async Task<IActionResult> Post([FromBody] UsuarioInput input)
        {
            try
            {
                var result = await _mediator.Send(
                new NewUsuarioCommand(
                    input.Nome,
                    input.Login,
                    input.Senha,
                    input.ConfirmarSenha,
                    input.Enderecos,
                    input.DDD,
                    input.Telefone)
                );
                if (result.Ok)
                    return Ok();
                return BadRequest(result.Errors);
            }
            catch(Exception ex)
            {
                //logar erro em algum lugar
                return StatusCode(500, ex.Message);
            }
        }
    }
}
