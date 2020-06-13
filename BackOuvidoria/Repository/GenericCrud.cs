using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public abstract class GenericCrud<T> : IGenericCrud<T> where T : class, new()
    {
        protected OuvidoriaDbContext _dbContext { get; set; }

        public async Task CreateAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> Read()
        {
            return _dbContext.Set<T>();
        }

        public async Task DeleteAsync(Func<T, bool> predicate)
        {
            _dbContext.Set<T>()
           .Where(predicate).ToList()
           .ForEach(del => _dbContext.Set<T>().Remove(del));
            await _dbContext.SaveChangesAsync();
        }
    }
}
