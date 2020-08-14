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

       

        public Pizza Pizza { get; set; }
        public Guid IdPizza { get; set; }
        public Sabor Sabor { get; set; }
        public Guid IdSabor { get; set; }
    }
}
