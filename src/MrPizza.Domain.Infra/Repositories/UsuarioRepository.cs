using MrPizza.Domain.Entities;
using MrPizza.Domain.Infra.Contexts;
using MrPizza.Domain.Interfaces.Repositories;

namespace MrPizza.Domain.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly MrPizzaContext _context;
        public UsuarioRepository(MrPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
