using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Infra.Contexts;

namespace MrPizza.Domain.Infra.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly MrPizzaContext _context;
        public EnderecoRepository(MrPizzaContext context) : base(context)
        {
            _context = context;
        }
    }
}
