using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Infra.Contexts;

namespace MrPizza.Domain.Infra.Repositories
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
