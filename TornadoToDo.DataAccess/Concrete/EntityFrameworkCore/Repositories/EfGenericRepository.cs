using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TornadoToDo.DataAccess.Context;
using TornadoToDo.DataAccess.Interface;

namespace TornadoToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new TornadoToDoDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            using var context = new TornadoToDoDbContext();
            return await context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new TornadoToDoDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new TornadoToDoDbContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter)
        {
            using var context = new TornadoToDoDbContext();
            return await context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(T entity)
        {
            using var context = new TornadoToDoDbContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new TornadoToDoDbContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
