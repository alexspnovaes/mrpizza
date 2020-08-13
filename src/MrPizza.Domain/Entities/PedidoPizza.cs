using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class PedidoPizza : BaseEntity
    {
        public Pizza Pizza { get; set; }
        public int IdPizza { get; set; }
        public Pedido Pedido { get; set; }
        public int IdPedido { get; set; }
    }
}
