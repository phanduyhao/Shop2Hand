using System;
using System.Collections.Generic;
using Shop2Hand.Models;

namespace Shop2Hand.ModelViews
{
    public class HomeViewVM
    {
        public List<News> ? TinTucs { get; set; }
        public List<ProductHomeVM> ? Products { get; set; }
    }
}
