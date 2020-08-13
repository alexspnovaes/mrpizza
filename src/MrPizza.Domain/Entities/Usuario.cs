using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string emailLogin, string senha, string ddd, string telefone, Endereco endereco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            EmailLogin = emailLogin;
            Senha = senha;
            DDD = ddd;
            Telefone = telefone;
            Endereco = endereco;
        }

        public string Nome { get; set; }
        public string EmailLogin { get; set; }
        public string Senha { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public List<Pedido> Pedidos { get; set; }
        public Guid IdEndereco { get; set; }
    }
}
