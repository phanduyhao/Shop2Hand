﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop2Hand.Models;
using Shop2Hand.ModelViews;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop2Hand.Controllers
{
    public class DonHangController : Controller
    {
        private readonly Shop2HandContext _context;
        public INotyfService _notyfService { get; }
        public DonHangController(Shop2HandContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [HttpPost]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var taikhoanID = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
                var khachhang = _context.Customers.AsNoTracking().SingleOrDefault(x => x.CustomerId == Convert.ToInt32(taikhoanID));
                if (khachhang == null) return NotFound();
                var donhang = await _context.Orders
                    .Include(x => x.OrderStatus)
                    .FirstOrDefaultAsync(m => m.OrderId == id && Convert.ToInt32(taikhoanID) == m.CustomerId);
                if (donhang == null) return NotFound();

                var chitietdonhang = _context.OrderDetails
                    .Include(x => x.Product)
                    .AsNoTracking()
                    .Where(x => x.OrderId == id)
                    .OrderBy(x => x.OrderDetailId)
                    .ToList();
                XemDonHang donHang = new XemDonHang();
                donHang.DonHang = donhang;
                donHang.ChiTietDonHang = chitietdonhang;
                return PartialView("Details", donHang);
                
            }
            catch 
            {
                return NotFound();
            }
        }
    }
}
