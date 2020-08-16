using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Endereco() { }
        public Endereco(string rua, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Id = Guid.NewGuid();
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public string Rua { get; }
        public string Numero { get; }
        public string Complemento { get; }
        public string Bairro { get; }
        public string Cep { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public Usuario Usuario { get; }
        public Guid? IdUsuario { get; }
    }
}
