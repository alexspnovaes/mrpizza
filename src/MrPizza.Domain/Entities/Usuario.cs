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

        public string Nome { get; set; }
        public string EmailLogin { get; set; }
        public string Senha { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
