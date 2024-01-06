using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.EFRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Concrete
{
    public class ProducerManager : IProducerService
    {
        //private readonly EFProducerRepository eFProducerRepository;
        private readonly IProducerDAL _producerDAL;
        public ProducerManager(IProducerDAL producerDAL)
        {
            _producerDAL = producerDAL ?? throw new ArgumentNullException(nameof(producerDAL)); ;
        }

        public Task AddAsync(Producer producer) => _producerDAL.AddAsync(producer);

        public Task DeleteAsync(int id) => _producerDAL.DeleteAsync(id);

        public Task<IEnumerable<Producer>> GetAllAsync() => _producerDAL.GetAllAsync();

        public Task<Producer> GetByIdAsync(int id) => _producerDAL.GetByIdAsync(id);

        public Task UpdateAsync(int id, Producer entity) => _producerDAL.UpdateAsync(id, entity);

        //public Task AddProducer(Producer producer) => _producerDAL.AddAsync(producer);

        //public Task Delete(Producer producer) => _producerDAL.DeleteAsync(producer.Id);
        //public Task<IEnumerable<Producer>> GetAll() => _producerDAL.GetAllAsync();

        //public Task<Producer> GetProducer(int id) => _producerDAL.GetByIdAsync(id);

        //public Task Update(Producer producer) => _producerDAL.UpdateAsync(producer.Id, producer);
    }
}
