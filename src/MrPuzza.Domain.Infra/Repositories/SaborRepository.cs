using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPuzza.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPuzza.Domain.Infra.Repositories
{
    public class SaborRepository : BaseRepository<Sabor>, ISaborRepository
    {
        private readonly MrPizzaContext _context;

        public SaborRepository(MrPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
