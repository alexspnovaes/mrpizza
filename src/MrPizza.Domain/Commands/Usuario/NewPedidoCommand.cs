using MediatR;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Models;
using System.Collections.Generic;

namespace MrPizza.Domain.Commands.Usuario
{
    public class NewUsuarioCommand : IRequest<GenericCommandResult>
    {
        public NewUsuarioCommand(string nome, string login, string senha, string confirmarSenha, List<EnderecoModel> enderecos, string ddd, string telefone)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
            Enderecos = enderecos;
            DDD = ddd;
            Telefone = telefone;
        }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public List<EnderecoModel> Enderecos { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
    }
}
