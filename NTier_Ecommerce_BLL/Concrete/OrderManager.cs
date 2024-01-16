using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDAL _orderDAL;
        public OrderManager(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole) =>
           await _orderDAL.GetOrdersByUserIdAndRoleAsync(userId, userRole);


        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress) =>
            await _orderDAL.StoreOrderAsync(items, userId, userEmailAddress);
    }
}
