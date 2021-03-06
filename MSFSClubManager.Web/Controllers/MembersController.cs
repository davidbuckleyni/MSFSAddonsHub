﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using NToastNotify;

namespace MSFSClubManager.Web.Controllers
{
    public class MembersController : BaseController
    {
        private readonly MSFSClubManagerDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;
        public Guid UserId { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }
        public MembersController(IHttpContextAccessor httpContextAccessor, MSFSClubManagerDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
        {

            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
            _toast = toast;

            userName = GetUserName().Result.ToString();

        }
   


        // GET: MembersController
        public  IActionResult Index()
        {
            var tennantId = GetTennantId().Result;
            return View(  _context.Members.Where(w => w.TennantId == tennantId).ToList());
        }

        // GET: MembersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
