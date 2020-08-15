using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrPizza.Domain.Commands.Autenticacao;

namespace MrPizza.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutenticacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromQuery] string login, [FromQuery] string senha)
        {
            try
            {
                var result = await _mediator.Send(new AutenticarUsuarioCommand(login, senha));
                if (result.Ok)
                    return Ok(result.Data);
                return BadRequest(result.Errors);
            }
            catch(Exception ex)
            {
                //logar erro em algum lugar
                return StatusCode(500,ex.Message);
            }
        }
    }
}
