using MrPizza.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MrPizza.Domain.Models
{
    public class PizzaSaborModel
    {
        public int Ordem { get; set; }
        public List<Guid> Sabores { get; set; }
    }
}
