using FluentValidation;
using MrPizza.Domain.Commands.Pedido;
using MrPizza.Domain.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MrPizza.Domain.Validators
{
    public class NewUsuarioCommandValidator : AbstractValidator<NewUsuarioCommand>
    {
        public NewUsuarioCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.DDD)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(2)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Login)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(100)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Senha)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(100)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.ConfirmarSenha)
              .NotEmpty()
              .WithMessage(ErrorMessages.EmptyField)
              .MaximumLength(100)
              .WithMessage(ErrorMessages.MaxLen)
              .Equal(x => x.Senha)
              .WithMessage(ErrorMessages.PassNoEqual);
            RuleFor(x => x.Telefone)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(9)
               .WithMessage(ErrorMessages.MaxLen);

            RuleForEach(end => end.Enderecos)
                .ChildRules(w =>
                {
                    w.RuleFor(x => x.Bairro)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(100)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Cep)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(8)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Complemento)
                    .MaximumLength(20)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Cidade)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(50)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Numero)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(10)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Rua)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(80)
                    .WithMessage(ErrorMessages.MaxLen);
                    w.RuleFor(x => x.Estado)
                    .NotEmpty()
                    .WithMessage(ErrorMessages.EmptyField)
                    .MaximumLength(2)
                    .WithMessage(ErrorMessages.MaxLen);
                });
        }
    }
}
