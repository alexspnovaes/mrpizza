using MediatR;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Models;
using System;
using System.Collections.Generic;

namespace MrPizza.Domain.Commands.Pedido
{
    public class NewPedidoCommand : IRequest<GenericCommandResult>
    {
        public NewPedidoCommand(List<PizzaSaborModel> pizzas, Guid? idUsuario, Endereco endereco)
        {
            Pizzas = pizzas;
            IdUsuario = idUsuario;
            Endereco = endereco;
        }

        public List<PizzaSaborModel> Pizzas { get; set; }
        public Guid? IdUsuario { get; set; }
        public Endereco Endereco { get; set; }
    }
}
