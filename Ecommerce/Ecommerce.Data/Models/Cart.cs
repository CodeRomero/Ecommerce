using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Sessions = new HashSet<Session>();
        }

        public int CartId { get; set; }
        public int? AccountId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public int? StoreId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
