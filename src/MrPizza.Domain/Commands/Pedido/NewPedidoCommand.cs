using MediatR;
using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MrPizza.Domain.Commands.Pedido
{
    public class NewPedidoCommand : IRequest<GenericCommandResult>
    {
        public NewPedidoCommand(List<PedidoPizza> pizzas, Guid? idUsuario, Endereco endereco)
        {
            Pizzas = pizzas;
            IdUsuario = idUsuario;
            Endereco = endereco;
        }

        public List<PedidoPizza> Pizzas { get; set; }
        public Guid? IdUsuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
