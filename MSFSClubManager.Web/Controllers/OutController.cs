using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSClubManager.Web.Controllers
{
    public class OutController : BaseController
    {
        private readonly MSFSClubManagerDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }

        private RoleManager<IdentityRole> roleManager;



        public OutController(IHttpContextAccessor httpContextAccessor, MSFSClubManagerDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
        {
            roleManager = roleMgr;

            _context = context;
            _userManager = userManager;
            _toast = toast;

            userName = GetUserName().Result.ToString();
            ViewBag.UserName = userName;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Invites(ClubInvitesViewModel invites)
        {



            return View();
        }

        
    }
}
