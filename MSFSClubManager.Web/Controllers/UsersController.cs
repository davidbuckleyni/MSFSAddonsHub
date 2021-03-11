using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using MSFSClubManager.Web;
using MSFSClubManager.Web.Controllers;
using MSFSClubManager.Web.Helpers;
using NToastNotify;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;

namespace Warehouse.Web.Controllers
{

    public class UsersController : BaseController
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly MSFSClubManagerDBContext _context;
        private readonly IToastNotification _toast;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UsersController(IHttpContextAccessor httpContextAccessor, MSFSClubManagerDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
        {
            _httpContextAccessor = httpContextAccessor;
            roleManager = roleMgr;
            _userManager = userManager;
            _context = context;

            _toast = toast;

        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
             

            var clubMembers = _context.ClubMembers.Where(w => w.UserId == id).FirstOrDefault();
            _context.ClubMembers.Remove(clubMembers);
            await _context.SaveChangesAsync();
             

            await HelperMethods.DeleteUserAccount(_userManager,clubMembers.User.Email,_context);
            _context.SaveChanges();
            _toast.AddWarningToastMessage($"User has been deleted {clubMembers.User.Email}");

            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(string id)
        {
            UserModalViewModel userModalViewModel = new UserModalViewModel();


            if (id == "0")
                return View(new UserModalViewModel());
            else
            {
                var user = _context.Users.Where(w => w.Id == id).FirstOrDefault();
                try
                {
                    userModalViewModel.FirstName = user.FirstName;
                    userModalViewModel.LastName = user.FirstName;
                    userModalViewModel.GamerTag = user.FirstName;
                    userModalViewModel.Email = user.Email;
                    
                    


                    return View(userModalViewModel);
                }
                catch (Exception ex)

                {
                }
                if (userModalViewModel == null)
                {
                    return NotFound();
                }

                return View(userModalViewModel);

            }
        }
        
        public UsersViewModel PopulateViewModel()
        {

            UsersViewModel usersViewModel = new UsersViewModel();
             usersViewModel.Users = _userManager.Users.ToList();
            return usersViewModel;
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
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }


        [HttpPost]
        public async Task<IActionResult> Submit(UserModalViewModel userModalViewModel)
        {

            if (((System.Security.Claims.ClaimsIdentity)User.Identity).IsInAnyRole(Constants.ClubSuperAdmin, Constants.ClubAdmin))
            {
                _toast.AddErrorToastMessage("Only Club Admins can create members");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = (string)userModalViewModel.Email, Email = userModalViewModel.Email,EmailConfirmed=true, FirstName = userModalViewModel.FirstName, LastName = userModalViewModel.LastName, GamerTag = userModalViewModel.GamerTag };
                var result = await _userManager.CreateAsync(user, userModalViewModel.Password);
                if (result.Succeeded)
                {

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    

                }
              
            }
            UsersViewModel modal = new UsersViewModel();
           
            modal = PopulateViewModel();
            _toast.AddSuccessToastMessage("User has been created");

            return View("~/Views/Users/Index.cshtml", modal);
 
        }



        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            List<ApplicationUser> members = new List<ApplicationUser>();
            List<ApplicationUser> nonMembers = new List<ApplicationUser>();
            foreach (ApplicationUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    ApplicationUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    ApplicationUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
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

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}

