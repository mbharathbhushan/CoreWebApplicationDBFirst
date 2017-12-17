using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreWebApplicationDBFirst.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(Func<T, bool> predicate);

        Task<IEnumerable<T>> GetBy(Func<T, bool> predicate);

        Task<T> Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task DeleteWhere(Func<T, bool> predicate);
    }
}
