using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Models
{
    public class PedidoModel
    {
        public DateTime DataHoraPedido { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
