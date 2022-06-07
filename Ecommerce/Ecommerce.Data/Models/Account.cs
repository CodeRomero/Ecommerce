using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Models
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Sessions = new HashSet<Session>();
        }

        public int AccountId { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string? Usrname { get; set; }
        public string? Pwd { get; set; }
        public string? Email { get; set; }
        public string? Membership { get; set; }
        public int? Balance { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
