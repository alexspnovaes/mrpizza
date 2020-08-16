using FluentValidation;
using MrPizza.Domain.Models;

namespace MrPizza.Domain.Validators
{
    public class EnderecoModelValidation : AbstractValidator<EnderecoModel>
    {
        public EnderecoModelValidation()
        {
            RuleFor(x => x.Bairro)
                .NotEmpty()
                .WithMessage(ErrorMessages.EmptyField)
                .MaximumLength(100)
                .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Cep)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(8)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Complemento)
               .MaximumLength(20)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Cidade)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(50)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Numero)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(10)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Rua)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(80)
               .WithMessage(ErrorMessages.MaxLen);
            RuleFor(x => x.Estado)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmptyField)
               .MaximumLength(2)
               .WithMessage(ErrorMessages.MaxLen);
        }
    }
}
