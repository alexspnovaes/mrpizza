using FluentValidation;
using MrPizza.Domain.Commands.Autenticacao;
using MrPizza.Domain.Commands.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MrPizza.Domain.Validators
{
    public class AutenticarUsuarioCommandValidator : AbstractValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioCommandValidator()
        {

            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField);
            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField);

        }
    }
}
