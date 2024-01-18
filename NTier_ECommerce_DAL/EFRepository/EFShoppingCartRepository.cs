using Microsoft.EntityFrameworkCore;
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
    public class EFShoppingCartRepository : GenericRepository<ShoppingCartItem>, IShoppingDAL
    {
        private readonly Context _context;
        private readonly string _shoppingCartId;
        public List<ShoppingCartItem> shoppingCartItems { get; set; }
        public EFShoppingCartRepository(Context context, string shoppingCartId = null) : base(context)
        {
            _shoppingCartId = shoppingCartId;
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == _shoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = _shoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            SaveChanges();
        }

        public async Task ClearShoppingCartAsyn()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == _shoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            SaveChangesAsync();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            
            return shoppingCartItems ?? (shoppingCartItems = _context.ShoppingCartItems.Where(x => x.ShoppingCartId == _shoppingCartId).Include(x => x.Movie).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == _shoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == _shoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            SaveChanges();
        }
        private void SaveChanges() => _context.SaveChanges();

        private async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
