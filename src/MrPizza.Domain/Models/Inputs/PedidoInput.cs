using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Models.Inputs
{
    public class PedidoInput
    {
        public PedidoInput(List<PizzaSaborModel> pizzas)
        {
            Pizzas = pizzas;
        }

        public List<PizzaSaborModel> Pizzas { get; set; }
    }
}
