using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TornadoToDo.DataAccess.Interface
{
    public interface IGenericDal<T> where T : class,new()
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);

        Task<List<T>> GetAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllByFilter(Expression<Func<T, bool>> filter);
    }
}
