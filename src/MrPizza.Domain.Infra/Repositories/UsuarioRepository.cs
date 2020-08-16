using Microsoft.EntityFrameworkCore;
using MrPizza.Domain.Entities;
using MrPizza.Domain.Infra.Contexts;
using MrPizza.Domain.Interfaces.Repositories;
using System;
using System.Linq;
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

        public async Task<Usuario> GetUserPedidos(Guid id)
        {
            return await _context.Usuario
                .Include("Pedidos.Pizzas.PizzaSabores.Sabor")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario> Get(string login, string senha)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.EmailLogin == login && u.Senha == senha);
        }

        public async Task<Usuario> Get(string login)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.EmailLogin == login);
        }


    }
}
