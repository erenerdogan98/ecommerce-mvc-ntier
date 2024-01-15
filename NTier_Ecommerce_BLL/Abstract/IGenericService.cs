// for Generic methods
using System.Linq.Expressions;

namespace NTier_Ecommerce_BLL.Abstract
{
    public interface IGenericService<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,T entity);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
    }
}
