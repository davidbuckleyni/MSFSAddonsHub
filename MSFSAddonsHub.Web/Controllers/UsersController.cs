using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSFSAddons.Dal.ViewModels;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using MSFSAddonsHub.Web.Controllers;
using NToastNotify;

namespace Warehouse.Web.Controllers {

    public class UsersController : BaseController {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly MSFSAddonDBContext _context;
        private readonly IToastNotification _toast;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UsersController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
        {
            _httpContextAccessor = httpContextAccessor;
            roleManager = roleMgr;
            _userManager = userManager; 
            _context = context;
            
            _toast = toast;

        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            UserViewModel usersViewModel = new UserViewModel();


            if (id == "")
                return View(new UserViewModel());
            else
            {
                var user = _context.Users.Where(w => w.Id == id).FirstOrDefault();
                try
                {
                    usersViewModel.User = user;
                    return View(usersViewModel);
                }
                catch (Exception ex)

                {
                }
                if (usersViewModel == null)
                {
                    return NotFound();
                }

                return View(usersViewModel);

            }
        }

            public async Task<IActionResult> Index()
        {


            UsersViewModel usersViewModel = new UsersViewModel();

            usersViewModel.Users = _userManager.Users.ToList();

            return View(usersViewModel);
    }
        public ViewResult Assign() => View();

        public IActionResult Create() => View();


        [HttpPost]
        public async Task<IActionResult> Create([Required] string name) {
            if (ModelState.IsValid) {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id) {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            if (role != null) {
                IdentityResult result = await roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            } else
                ModelState.AddModelError("", "No role found");
            return View("Index", roleManager.Roles);
        }


        public async Task<IActionResult> Update(string id) {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();
            foreach (ApplicationUser user in _userManager.Users) {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model) {
            IdentityResult result;
            if (ModelState.IsValid) {
                foreach (string userId in model.AddIds ?? new string[] { }) {
                    ApplicationUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null) {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { }) {
                    ApplicationUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null) {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }

        private void Errors(IdentityResult result) {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}

