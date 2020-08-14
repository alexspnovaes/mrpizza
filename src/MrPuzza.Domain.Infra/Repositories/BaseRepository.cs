using MrPizza.Domain.Entities;
using MrPizza.Domain.Interfaces.Repositories;
using MrPizza.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MrPizza.Domain.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MrPizzaContext _context;
        public BaseRepository(MrPizzaContext context)
        {
            _context = context;
        }
        public async Task Create(T obj)
        {
            await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T obj)
        {
             _context.Remove(obj);
            await _context.SaveChangesAsync();
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
