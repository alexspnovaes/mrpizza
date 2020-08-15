using MediatR;
using MrPizza.Domain.Commands.Usuario;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Utils;
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
            var passEncrypt = PasswordEncrypt.Encrypt(request.Senha);
            var enderecos = request.Enderecos.Select(s => new Endereco
            {
                Bairro = s.Bairro,
                Cep = s.Cep,
                Cidade = s.Cidade,
                Complemento = s.Complemento,
                Estado = s.Estado,
                Numero = s.Numero,
                Rua = s.Rua
            }).ToList();
            var Usuario = new Usuario(request.Nome, request.Login, passEncrypt, request.DDD, request.Telefone, enderecos);
            await _usuarioRepository.Create(Usuario);
            return GenericCommandResult.Success();
        }
    }
}
