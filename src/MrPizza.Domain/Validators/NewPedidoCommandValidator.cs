using FluentValidation;
using MrPizza.Domain.Commands.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MrPizza.Domain.Validators
{
    public class NewPedidoCommandValidator : AbstractValidator<NewPedidoCommand>
    {
        public NewPedidoCommandValidator()
        {

            RuleFor(x => x.Pizzas)
                .Must(x => x.Count <= 10)
                .WithMessage(ErrorMessages.MaxPizzasAllowed);
            RuleForEach(x => x.Pizzas)
                .ChildRules(w =>
                {
                    w
                        .RuleFor(sabor => sabor.Sabores.Count)
                        .LessThanOrEqualTo(2)
                        .WithMessage(ErrorMessages.MaxSaboresAllowed);
                });
            
        }
    }
}
