using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public Pizza(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
        }
        public List<PedidoPizza> PedidosPizzas { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
