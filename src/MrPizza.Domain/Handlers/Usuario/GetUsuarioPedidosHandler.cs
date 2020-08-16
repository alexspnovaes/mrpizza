using MediatR;
using MrPizza.Domain.Commands.Usuario;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Models;
using MrPizza.Domain.Utils;
using MrPizza.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MrPizza.Domain.Handlers.NewUsuarioUsuarioHandler
{

    public class GetUsuarioPedidosHandler : IRequestHandler<GetUsuarioPedidosCommand, GenericCommandResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioPedidosHandler(IUsuarioRepository UsuarioRepository)
        {
            _usuarioRepository = UsuarioRepository;
        }

        public async Task<GenericCommandResult> Handle(GetUsuarioPedidosCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetUserPedidos(request.Id);
            var result = new UsuarioPedidosModel
            {
                Pedidos = usuario.Pedidos.Select(p => new PedidoModel
                {
                    DataHoraPedido = p.DataHoraPedido,
                    ValorTotal = p.Pizzas.Sum(s => s.Valor),
                    Pizzas = p.Pizzas.Select(pi => new PizzaModel
                    {
                        Id = pi.Id,
                        Valor = pi.Valor,
                        PizzaSabores = pi.PizzaSabores.Select(ps => new SaborModel
                        {
                            Descricao = ps.Sabor.Descricao,
                            Valor = ps.Sabor.Valor
                        }).ToList()
                    }).ToList()
                })
                .OrderByDescending(o => o.DataHoraPedido)
                .ToList()
            };
            return GenericCommandResult.Success(result);
        }
    }
}
