using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class FavoriteStore
    {
        public string? Favorited { get; set; }
        public int? StoreId { get; set; }
        public int? AccountId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Store? Store { get; set; }
    }
}
