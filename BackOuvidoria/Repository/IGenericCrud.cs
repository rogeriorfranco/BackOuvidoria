using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ouvidoria.Repository
{
    public interface IGenericCrud<T>
    {
        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        IQueryable<T> Read();

        Task DeleteAsync(Func<T, bool> predicate);
    }
}
