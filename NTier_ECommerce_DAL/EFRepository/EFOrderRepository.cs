using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier_ECommerce_DAL.EFRepository
{
    public class EFOrderRepository : IOrderDAL
    {
        private readonly Context _context;

        public EFOrderRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            throw new NotImplementedException();
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
