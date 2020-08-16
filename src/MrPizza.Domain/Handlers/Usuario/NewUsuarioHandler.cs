using MediatR;
using MrPizza.Domain.Commands.Usuario;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Utils;
using MrPizza.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MrPizza.Domain.Handlers.NewUsuarioUsuarioHandler
{

    public class NewUsuarioHandler : IRequestHandler<NewUsuarioCommand, GenericCommandResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public NewUsuarioHandler(IUsuarioRepository UsuarioRepository)
        {
            _usuarioRepository = UsuarioRepository;
        }

        public async Task<GenericCommandResult> Handle(NewUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.Get(request.Login);
            if (usuario != null)
                return GenericCommandResult.Failure(new List<string> { ErrorMessages.UserAlreadyExists });

            var validator = new NewUsuarioCommandValidator();
            var results = validator.Validate(request);
            
            if (!results.IsValid)
                return GenericCommandResult.Failure(results.Errors);


            var passEncrypt = PasswordEncrypt.Encrypt(request.Senha);
            var enderecos = request.Enderecos.Select(s => new Endereco(s.Rua, s.Numero, s.Complemento, s.Bairro, s.Cep, s.Cidade, s.Estado)).ToList();
            var Usuario = new Usuario(request.Nome, request.Login, passEncrypt, request.DDD, request.Telefone, enderecos);
            await _usuarioRepository.Create(Usuario);
            return GenericCommandResult.Success();
        }
    }
}
