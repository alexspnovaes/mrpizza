using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public List<PedidoPizza> PedidosPizzas { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdEndereco { get; set; }
        public DateTime DataHoraPedido { get; set; }
    }
}
