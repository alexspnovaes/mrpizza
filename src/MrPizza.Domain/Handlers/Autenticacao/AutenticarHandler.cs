using MediatR;
using MrPizza.Domain.Commands.Autenticacao;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Models;
using MrPizza.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;
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
            var usuario = await _usuarioRepository.Get(request.Login, PasswordEncrypt.Encrypt(request.Senha));
            var retorno = new UsuarioModel { Login = usuario.EmailLogin, Nome = usuario.Nome, Token = Token.GenerateNewToken(usuario.Nome) };
            return GenericCommandResult.Success(retorno);
        }
    }
}
