using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public List<PedidoPizza> PedidosPizzas { get; set; }
        public List<PizzaSabor> PizzaSabores { get; set; }
        public decimal Valor { get; set; }
    }
}
