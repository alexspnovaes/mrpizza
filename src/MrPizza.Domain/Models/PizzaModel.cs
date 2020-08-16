using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Models
{
    public class PizzaModel
    {
        public Guid Id { get; set; }
        public List<SaborModel> PizzaSabores { get; set; }
        public decimal Valor { get; set; }
    }
}
