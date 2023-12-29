using NTier_Ecommerce_BLL.Abstract;
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
        private readonly EFProducerRepository eFProducerRepository;
        public ProducerManager(EFProducerRepository eFProducerRepository)
        {
            this.eFProducerRepository = eFProducerRepository ?? throw new ArgumentNullException(nameof(eFProducerRepository)); ;
        }

        public Task AddProducer(Producer producer) => eFProducerRepository.AddAsync(producer);

        public Task Delete(Producer producer) => eFProducerRepository.DeleteAsync(producer.Id);
        public Task<IEnumerable<Producer>> GetAll() => eFProducerRepository.GetAllAsync();

        public Task<Producer> GetProducer(int id) => eFProducerRepository.GetByIdAsync(id);

        public Task Update(Producer producer) => eFProducerRepository.UpdateAsync(producer.Id, producer);
    }
}
