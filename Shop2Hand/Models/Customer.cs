﻿using System;
using System.Collections.Generic;

namespace Shop2Hand.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Avatar { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public DateTime? Lastlogin { get; set; }
        public bool Active { get; set; }
        public string? Email2 { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
