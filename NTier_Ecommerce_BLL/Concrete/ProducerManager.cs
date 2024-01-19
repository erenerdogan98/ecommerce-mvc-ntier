using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_Entities;
using System.Linq.Expressions;


namespace NTier_Ecommerce_BLL.Concrete
{
    public class ProducerManager : IProducerService
    {
        private readonly IProducerDAL _producerDAL;
        public ProducerManager(IProducerDAL producerDAL)
        {
            _producerDAL = producerDAL ?? throw new ArgumentNullException(nameof(producerDAL)); ;
        }

        public Task AddAsync(Producer producer) => _producerDAL.AddAsync(producer);

        public Task DeleteAsync(int id) => _producerDAL.DeleteAsync(id);

        public Task<IEnumerable<Producer>> GetAllAsync() => _producerDAL.GetAllAsync();

        public Task<IEnumerable<Producer>> GetAllAsync(params Expression<Func<Producer, object>>[] includeProperties) =>
            _producerDAL.GetAllAsync(includeProperties);

        public Task<Producer> GetByIdAsync(int id) => _producerDAL.GetByIdAsync(id);

        public async Task<Producer> GetByIdAsync(int id, params Expression<Func<Producer, object>>[] includeProperties) =>
            await _producerDAL.GetByIdAsync(id, includeProperties);

        public Task UpdateAsync(int id, Producer entity) => _producerDAL.UpdateAsync(id, entity);
    }
}
