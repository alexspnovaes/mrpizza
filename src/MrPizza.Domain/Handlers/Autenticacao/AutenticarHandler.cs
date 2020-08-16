using MediatR;
using MrPizza.Domain.Commands.Autenticacao;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Models;
using MrPizza.Domain.Utils;
using MrPizza.Domain.Validators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MrPizza.Domain.Handlers.Autenticacao
{
    public class AutenticarHandler : IRequestHandler<AutenticarUsuarioCommand, GenericCommandResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticarHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<GenericCommandResult> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var validator = new AutenticarUsuarioCommandValidator();
            var results = validator.Validate(request);
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);

            var usuario = await _usuarioRepository.Get(request.Login, PasswordEncrypt.Encrypt(request.Senha));

            if (usuario is null)
                return GenericCommandResult.Failure(new List<string> { ErrorMessages.WrongUser });

            var retorno = new UsuarioModel { Login = usuario.EmailLogin, Nome = usuario.Nome, Token = Token.GenerateNewToken(usuario.EmailLogin) };
            return GenericCommandResult.Success(retorno);
        }
    }
}
