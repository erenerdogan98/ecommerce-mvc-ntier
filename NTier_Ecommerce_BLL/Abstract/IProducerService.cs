using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Abstract
{
    public interface IProducerService
    {
        Task AddProducer(Producer producer);
        Task Update(Producer producer);
        Task Delete(Producer producer);
        Task<IEnumerable<Producer>> GetAll();
        Task<Producer> GetProducer(int id);
    }
}
