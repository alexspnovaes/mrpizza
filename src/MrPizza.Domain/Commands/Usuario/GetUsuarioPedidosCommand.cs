using MediatR;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Models;
using System;
using System.Collections.Generic;

namespace MrPizza.Domain.Commands.Usuario
{
    public class GetUsuarioPedidosCommand : IRequest<GenericCommandResult>
    {
        public GetUsuarioPedidosCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
