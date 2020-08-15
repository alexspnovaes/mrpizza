using Microsoft.EntityFrameworkCore;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Infra.Contexts;
using MrPizza.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace MrPizza.Domain.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly MrPizzaContext _context;
        public UsuarioRepository(MrPizzaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> Get(string login, string senha)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.EmailLogin == login && u.Senha == senha);
        }

       
    }
}
