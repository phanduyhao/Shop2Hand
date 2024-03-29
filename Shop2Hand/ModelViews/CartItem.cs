﻿using Shop2Hand.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop2Hand.ModelViews
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public Product? product { get; set; }
        public int amount { get; set; }
        public double TotalMoney => amount * product.Price.Value;
    }
}
