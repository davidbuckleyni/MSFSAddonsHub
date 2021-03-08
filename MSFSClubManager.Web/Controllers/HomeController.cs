﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using MSFSClubManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSClubManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MSFSAddonDBContext _context;
        public HomeController(ILogger<HomeController> logger,MSFSAddonDBContext context)
        {
        _context = context;      
        _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
