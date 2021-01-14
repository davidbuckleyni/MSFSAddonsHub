using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Web.Controllers
{
    public class AdminDashBoardController : Controller
    {
        [Route("Admin/Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Admin/DashBoard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
