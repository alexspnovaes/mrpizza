using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Models.Inputs
{
    public class PedidoSemLoginInput : PedidoInput
    {
        public PedidoSemLoginInput(List<PizzaSaborModel> pizzas, EnderecoModel endereco) : base(pizzas)
        {
            Endereco = endereco;
        }

        public EnderecoModel Endereco { get; set; }
    }
}
