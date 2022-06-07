using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Discount
    {
        public int DiscountId { get; set; }
        public string? Description { get; set; }
        public string DiscountName { get; set; } = null!;
        public double PriceModifier { get; set; }
    }
}
