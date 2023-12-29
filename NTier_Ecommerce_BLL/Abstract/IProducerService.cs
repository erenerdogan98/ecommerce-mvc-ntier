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
        public void AddProducer(Producer producer);
        public void Update(Producer producer);
        public void Delete(Producer producer);
        public IEnumerable<Producer> GetAll();
        Producer GetProducer(int id);
    }
}
