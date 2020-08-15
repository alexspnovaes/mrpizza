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

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public Guid? IdUsuario { get; set; }
    }
}
