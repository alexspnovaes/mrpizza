using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Usuario : BaseEntity
    {
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
