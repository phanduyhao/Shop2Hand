using Shop2Hand.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Shop2Hand.ModelViews
{
    public class XemDonHang
    {
        [Key]
        public int Id { get; set; }
        public Order? DonHang { get; set; }
        public List<OrderDetail>? ChiTietDonHang { get; set; }
    }
}
