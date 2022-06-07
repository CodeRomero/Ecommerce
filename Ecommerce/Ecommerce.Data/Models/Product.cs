using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int Sku { get; set; }
        public string Make { get; set; } = null!;
        public string Text { get; set; } = null!;
        public decimal? Price { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
