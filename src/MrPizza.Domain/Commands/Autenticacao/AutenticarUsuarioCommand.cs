using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Commands.Autenticacao
{
    public class AutenticarUsuarioCommand : IRequest<GenericCommandResult>
    {
        public AutenticarUsuarioCommand(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public string Login { get; }
        public string Senha { get; }
    }
}
