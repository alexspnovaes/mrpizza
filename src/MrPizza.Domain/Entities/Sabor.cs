using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class Sabor : BaseEntity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public List<PizzaSabor> PizzaSabores { get; set; }
    }
}
