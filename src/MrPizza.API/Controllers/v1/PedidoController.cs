using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrPizza.Domain.Commands.Pedido;

namespace MrPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Post([FromBody] NewPedidoCommand command)
        {
            var result = await _mediator.Send(new NewPedidoCommand(command.Pizzas, command.IdUsuario, command.Endereco));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
    }
}
