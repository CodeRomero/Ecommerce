using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
using Ecommerce.Data.Models;

namespace Ecommerce.BL
{
    public class CartCheckout
    {
        #region Constructor
        public CartCheckout(p1mvcecommerceSQLDbContext context)
        {
            this.dBContext = context;
            products = new List<Product>();
        }
        #endregion

        private readonly p1mvcecommerceSQLDbContext dBContext;
        //private List<P1Models.Order> _ord;
        // private List<Product> _prod;
        public List<Product> products { get; set; }
        public Data.Models.Account account;



        // AddProductAsync
       /* public async Task<bool> AddProductAsync(Product p)
        {
            Products.Add(p);
            var n = new CartProduct(1, p.ProductId);
            await _context.AddAsync(n);
            await _context.SaveChangesAsync();

            return true;
        }
       */

        //Display an order
        //public async Task<List<CartProduct>> ListOfCartProductsAsync()
        //{
        //    //  ps = _context.Users.ToList();
        //    ps = _context.CartProducts.ToList();

        //    return ps;
        //}

    }
}
