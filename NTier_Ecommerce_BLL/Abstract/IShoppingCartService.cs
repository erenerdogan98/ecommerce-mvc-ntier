using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Abstract
{
    public interface IShoppingCartService : IGenericService<ShoppingCartItem>
    {
        public double GetShoppingCartTotal();
        public void AddItemToCart(Movie movie);
        public void RemoveItemFromCart(Movie movie);
        public Task ClearShoppingCartAsyn();
        public List<ShoppingCartItem> GetShoppingCartItems();
    }
}
