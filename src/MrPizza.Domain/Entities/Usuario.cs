using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario()
        {
        }

        public Usuario(string nome, string emailLogin, string senha, string ddd, string telefone, List<Endereco> enderecos)
        {
            Nome = nome;
            EmailLogin = emailLogin;
            Senha = senha;
            DDD = ddd;
            Telefone = telefone;
            Enderecos = enderecos;
        }

        public string Nome { get; }
        public string EmailLogin { get; }
        public string Senha { get; }
        public string DDD { get; }
        public string Telefone { get; }
        public List<Endereco> Enderecos { get; }
        public List<Pedido> Pedidos { get; }
    }
}
