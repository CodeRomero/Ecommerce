using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Store
    {
        public Store()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string? Address { get; set; }
        public string Phone { get; set; } = null!;

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
