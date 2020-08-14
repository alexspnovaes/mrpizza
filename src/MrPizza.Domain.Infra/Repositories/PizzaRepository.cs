using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Infra.Contexts;

namespace MrPizza.Domain.Infra.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaSaborRepository
    {
        private readonly MrPizzaContext _context;

        public PizzaRepository(MrPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
