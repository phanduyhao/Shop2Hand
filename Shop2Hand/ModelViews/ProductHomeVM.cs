using System;
using System.Collections.Generic;
using Shop2Hand.Models;

namespace Shop2Hand.ModelViews
{
    public class ProductHomeVM
    {
        public Category ? category { get; set; }
        public List<Product> ? lsProducts { get; set; }
    }
}
