using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPuzza.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrPuzza.Domain.Infra.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly MrPizzaContext _context;
        public PedidoRepository(MrPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
