using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Pedido : BaseEntity
    {
        public Pedido() { }
        public Pedido(List<Pizza> pizzas, Guid? idUsuario, Guid? idEndereco, DateTime dataHoraPedido)
        {
            Id = Guid.NewGuid();
            Pizzas = pizzas;
            IdUsuario = idUsuario;
            IdEndereco = idEndereco;
            DataHoraPedido = dataHoraPedido;
        }

        public List<Pizza> Pizzas { get; set; }
        public Guid? IdUsuario { get; set; }
        public Guid? IdEndereco { get; set; }
        public DateTime DataHoraPedido { get; set; }
    }
}
