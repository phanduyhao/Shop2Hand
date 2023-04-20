﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Shop2Hand.Models;

namespace Shop2Hand.Controllers
{
    public class PageController : Controller
    {
        private readonly Shop2HandContext _context;
        public PageController(Shop2HandContext context)
        {
            _context = context;
        }
      
        [Route("/Page/{Alias}", Name = "PageDetails")]
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias)) return RedirectToAction("Index", "Home");
            var page = _context.Pages.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
            if (page == null)
            {
                return RedirectToAction("Index");
            }
          
            return View(page);
        }
    }
}
