using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPuzza.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrPuzza.Domain.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MrPizzaContext _context;
        public BaseRepository(MrPizzaContext context)
        {
            _context = context;
        }
        public Task Create(T obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
