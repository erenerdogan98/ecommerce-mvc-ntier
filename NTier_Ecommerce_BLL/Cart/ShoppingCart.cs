using Microsoft.Extensions.DependencyInjection;
using NTier_Ecommerce_BLL.Abstract;
using NTier_ECommerce_DAL.Abstract;
using NTier_ECommerce_DAL.Database;
using NTier_ECommerce_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTier_Ecommerce_BLL.Cart
{
    public class ShoppingCart : IShoppingCartService
    {
        //public Context _context { get; set; }

        //public string ShoppingCartId { get; set; }
        //public List<ShoppingCartItem> ShoppingCartName { get; set; }

        //public ShoppingCart(Context context)
        //{
        //    _context = context;
        //}

        //public static ShoppingCart GetShoppingCart(IServiceProvider services)
        //{
        //    ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        //    var context = services.GetService<AppDbContext>();

        //    string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        //    session.SetString("CartId", cartId);

        //    return new ShoppingCart(context) { ShoppingCartId = cartId };
        //}
        private readonly IShoppingDAL _shoppingDAL;
        public ShoppingCart(IShoppingDAL shoppingDAL)
        {
            _shoppingDAL = shoppingDAL ?? throw new ArgumentNullException(nameof(_shoppingDAL));
        }

        public async Task AddAsync(ShoppingCartItem shoppingCart)
        {
            await _shoppingDAL.AddAsync(shoppingCart);
        }

        public void AddItemToCart(Movie movie)
        {
            _shoppingDAL.AddItemToCart(movie);
        }

        public async Task ClearShoppingCartAsyn() =>
        
          await _shoppingDAL.ClearShoppingCartAsyn();
        

        public async Task DeleteAsync(int id)
        {
            await _shoppingDAL.DeleteAsync(id);
        }

        public Task<IEnumerable<ShoppingCartItem>> GetAllAsync(params Expression<Func<ShoppingCartItem, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<ShoppingCartItem> GetByIdAsync(int id, params Expression<Func<ShoppingCartItem, object>>[] includeProperties)
        {
            var items = await _shoppingDAL.GetAllAsync(includeProperties);
            return items.FirstOrDefault(item => item.Id == id);
        }

        public async Task<ShoppingCartItem> GetByIdAsync(int id) => await _shoppingDAL.GetByIdAsync(id);

        public List<ShoppingCartItem> GetShoppingCartItems() =>
            _shoppingDAL.GetShoppingCartItems();
        

        public double GetShoppingCartTotal() => _shoppingDAL.GetShoppingCartTotal();

        public void RemoveItemFromCart(Movie movie)
        {
            _shoppingDAL.RemoveItemFromCart(movie);
        }

        public async Task UpdateAsync(int id, ShoppingCartItem shoppingCart)
        {
            await _shoppingDAL.UpdateAsync(id, shoppingCart);
        }
    }
}
