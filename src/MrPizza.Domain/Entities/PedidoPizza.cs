using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class PedidoPizza : BaseEntity
    {
        public Pizza Pizza { get; set; }
        public Guid IdPizza { get; set; }
        public Pedido Pedido { get; set; }
        public Guid IdPedido { get; set; }
    }
}
