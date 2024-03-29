﻿using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;

namespace NTier_ECommerce_DAL.EFRepository
{
    public class EFProducerRepository : GenericRepository<Producer> , IProducerDAL
    {
        public EFProducerRepository(Context context) : base(context)
        {
            
        }
    }
}
