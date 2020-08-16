using FluentValidation;
using MrPizza.Domain.Commands.Pedido;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Validators
{
    public class NewPedidoCommandValidator : AbstractValidator<NewPedidoCommand>
    {
        public NewPedidoCommandValidator()
        {
            RuleForEach(x => x.Pizzas)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyPizzas);
            RuleFor(x => x.Pizzas)
                .Must(x => x.Count <= 10)
                .WithMessage(ErrorMessages.MaxPizzasAllowed);
        }
    }
}
