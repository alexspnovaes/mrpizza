using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public Pizza()
        {
        }

        public Pizza(Pedido pedido,  decimal valor)
        {
            Id = Guid.NewGuid();
            Pedido = pedido;
            Valor = valor;
        }

        public Pedido Pedido { get; }
        public List<PizzaSabor> PizzaSabores { get; set; }
        public decimal Valor { get; }
    }
}
