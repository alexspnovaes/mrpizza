using MediatR;
using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MrPizza.Domain.Handlers.NewPedidoHandler
{

    public class NewPedidoHandler : IRequestHandler<NewPedidoCommand, GenericCommandResult>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ISaborRepository _saborRepository;
        public NewPedidoHandler(IPedidoRepository pedidoRepository, IEnderecoRepository enderecoRepository,  ISaborRepository saborRepository)
        {
            _pedidoRepository = pedidoRepository;
            _enderecoRepository = enderecoRepository;
            _saborRepository = saborRepository;
        }

        public async Task<GenericCommandResult> Handle(NewPedidoCommand request, CancellationToken cancellationToken)
        {
            List<Pizza> pizzas = new List<Pizza>();
            var endereco = new Endereco(request.Endereco.Rua, request.Endereco.Numero, request.Endereco.Complemento, request.Endereco.Bairro, request.Endereco.Cep, request.Endereco.Cidade, request.Endereco.Estado);
            var pedido = new Pedido(pizzas, request.IdUsuario, endereco.Id, DateTime.Now);
            var sabores = await _saborRepository.Get();
            foreach (var p in request.Pizzas)
            {
                var pizza = new Pizza(pedido,sabores.Where(x => p.Sabores.Contains(x.Id)).Sum(s => s.Valor) / p.Sabores.Count);
                pizza.PizzaSabores = p.Sabores.Select(s => new PizzaSabor(pizza.Id, s)).ToList();
                pizzas.Add(pizza);
            }
            await _enderecoRepository.Create(endereco);
            await _pedidoRepository.Create(pedido);
            return GenericCommandResult.Success(pedido);
        }
    }
}
