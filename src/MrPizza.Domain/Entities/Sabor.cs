using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Sabor : BaseEntity
    {
        public Sabor(string descricao, decimal valor)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            Valor = valor;
        }

        public string Descricao { get;  }
        public decimal Valor { get; }
        public List<PizzaSabor> PizzaSabores { get; }
    }
}
