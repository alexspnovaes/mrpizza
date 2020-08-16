using System;
using System.Collections.Generic;
using System.Text;

namespace MrPizza.Domain.Entities
{
    public class PizzaSabor : BaseEntity
    {
        public PizzaSabor()
        {
        }

        public PizzaSabor(Guid idPizza, Guid idSabor)
        {
            Id = Guid.NewGuid();
            IdPizza = idPizza;
            IdSabor = idSabor;
        }

       

        public Pizza Pizza { get;  }
        public Guid IdPizza { get; }
        public Sabor Sabor { get; }
        public Guid IdSabor { get; }
    }
}
