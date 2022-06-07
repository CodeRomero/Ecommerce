using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public int? AccountId { get; set; }
        public int? CartId { get; set; }

        public virtual Account? Account { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
