// for Generic methods
namespace NTier_Ecommerce_BLL.Abstract
{
    public interface IGenericService<T>
    {
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
