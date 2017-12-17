using CoreWebApplicationDBFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreWebApplicationDBFirst.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EmployeeDBContext employeeDBContext;

        protected BaseRepository(EmployeeDBContext employeeDBContext)
        {
            this.employeeDBContext = employeeDBContext;
        }

        public async Task<T> Create(T entity)
        {
            EntityEntry dbEntityEntry = employeeDBContext.Entry(entity);
            var response = await employeeDBContext.Set<T>().AddAsync(entity);
            await employeeDBContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task Delete(T entity)
        {
            EntityEntry dbEntityEntry = employeeDBContext.Entry(entity);
            dbEntityEntry.State = EntityState.Deleted;
            await employeeDBContext.SaveChangesAsync();
        }

        public async Task DeleteWhere(Func<T, bool> predicate)
        {
            IEnumerable<T> entities = employeeDBContext.Set<T>().Where(FuncToExpression(predicate));
            foreach (var entity in entities)
            {
                employeeDBContext.Entry(entity).State = EntityState.Deleted;
            }

            await employeeDBContext.SaveChangesAsync();
        }

        public virtual async Task<T> Get(Func<T, bool> predicate)
        {
            return await employeeDBContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(FuncToExpression(predicate));
        }

        public async Task<IEnumerable<T>> GetBy(Func<T, bool> predicate)
        {
            return await employeeDBContext.Set<T>().AsNoTracking().Where(FuncToExpression(predicate)).ToListAsync();
        }

        public async Task Update(T entity)
        {
            EntityEntry dbEntityEntry = employeeDBContext.Entry(entity);
            dbEntityEntry.State = EntityState.Modified;
            await employeeDBContext.SaveChangesAsync();
        }

        protected static Expression<Func<T, bool>> FuncToExpression(Func<T, bool> f)
        {
            return x => f(x);
        }
    }
}
