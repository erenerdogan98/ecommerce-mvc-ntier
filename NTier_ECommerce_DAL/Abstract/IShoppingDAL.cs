using NTier_ECommerce_DAL.GenericRepository;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.Abstract
{
    public interface IShoppingDAL : IGenericRepository<ShoppingCartItem>
    {
        public double GetShoppingCartTotal();
        public void AddItemToCart(Movie movie);
        public void RemoveItemFromCart(Movie movie);
        public  Task ClearShoppingCartAsyn();
    }
}
