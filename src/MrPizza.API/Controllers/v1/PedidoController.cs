using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Models.Inputs;

namespace MrPizza.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _usuarioRepository;

        public PedidoController(IMediator mediator, IUsuarioRepository usuarioRepository)
        {
            _mediator = mediator;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("SemLogin")]
        public async Task<IActionResult> OrderWithoutLogin([FromBody] PedidoSemLoginInput pedido)
        {
            var result = await _mediator.Send(new NewPedidoCommand(pedido.Pizzas, null, pedido.Endereco));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] PedidoInput pedido)
        {
            var login = User.Identity.Name;
            var usuario = await _usuarioRepository.Get(login);
            var result = await _mediator.Send(new NewPedidoCommand(pedido.Pizzas, usuario.Id, null));
            if (result.Ok)
                return Ok(result.Data);
            return BadRequest(result.Errors);
        }
    }
}
