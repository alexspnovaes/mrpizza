using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MrPizza.Domain;
using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Commands.Usuario;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Models;
using MrPizza.Domain.Models.Inputs;

namespace MrPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
        }


        [ProducesResponseType(typeof(UsuarioPedidosModel), 200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet("pedidos")]
        [Authorize]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                var login = User.Identity.Name;
                var usuario = await _usuarioRepository.Get(login);
                if (usuario == null)
                    return BadRequest(GenericCommandResult.Failure(new List<string> { ErrorMessages.UserNotExists }));

                var result = await _mediator.Send(new GetUsuarioPedidosCommand(usuario.Id));
                if (result.Ok)
                    return Ok(result.Data);
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                //logar erro em algum lugar
                return StatusCode(500, ex.Message);
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string[]), 400)]
        [ProducesResponseType(500)]
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
