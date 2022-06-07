using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int? AccountId { get; set; }
        public int? Quanity { get; set; }
        public double? Total { get; set; }
        public DateTimeOffset CreatedAtTime { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
    }
}
