using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Inventory
    {
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int? StoreQuantity { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
    }
}
