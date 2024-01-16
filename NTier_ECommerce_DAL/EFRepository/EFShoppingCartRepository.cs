using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.EFRepository
{
    public class EFShoppingCartRepository : GenericRepository<ShoppingCartItem> , IShoppingDAL
    {
        public EFShoppingCartRepository(Context context) : base(context)
        {         
        }
    }
}
