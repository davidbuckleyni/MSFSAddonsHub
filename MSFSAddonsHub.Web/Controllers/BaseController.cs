using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MSFSAddonsHub.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MSFSAddonsHub.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using NToastNotify;
using MSFSAddonsHub.Web.Helpers;

namespace MSFSAddonsHub.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly MSFSAddonDBContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private MSFSAddonDBContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userMrg;
        private IToastNotification toast;
        private RoleManager<IdentityRole> roleMgr;
        private IHttpContextAccessor httpContextAccessor;

        public ApplicationUser? AppUser { get; set; }
        public BaseController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager,  RoleManager<IdentityRole> roleMgr)
        {
            _httpContextAccessor = httpContextAccessor;
            roleManager = roleMgr;

            _context = context;
            _userManager = userManager;
            
            GetUserId();
            GetEmailAddress();
            IsCurrentUserClubAdmin();
          }

        public BaseController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userMrg, IToastNotification toast, RoleManager<IdentityRole> roleMgr)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
            this.userMrg = userMrg;
            this.toast = toast;
            this.roleMgr = roleMgr;
        }

        protected async Task<Guid>? GetTennantId()
        {
            var tennantId =  _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.TennantId;
            return ((Guid)(tennantId));
        }
        protected async Task<string> GetUserName()
        {
            var userName = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            return (userName.FirstName + " " + userName.LastName);
        }
        public Guid UserId { get; set; }
        protected void GetUserId()
        {
            var userId = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.Id;

            Guid.TryParse(userId, out Guid userIdResult);
            UserId = userIdResult;

        }
        public bool IsClubAdmin()
        {
            return User.IsInAnyRole(Constants.ClubSuperAdmin, Constants.ClubMod);


        }
   
        public Guid? ClubId { get; set; }
        protected void GetClubId()
        {
            var clubId =  _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.ClubId;
            ClubId = clubId;
            

        }
 
      

        public string Email { get; set; }
        protected void GetEmailAddress()
        {
            Email = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.NormalizedEmail.ToLower();

            
            

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.Id;
            var FirstName = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.FirstName;
            var LastName = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.LastName;
            ViewBag.Initials = FirstName.Substring(0, 1) + " " + LastName.Substring(0, 1);
            ViewBag.FullName = FirstName + " " + LastName;
            base.OnActionExecuting(filterContext);

        }
        public bool isClubAdmin { get; set; }
        private  bool IsCurrentUserClubAdmin()
        {
            return User.IsInAnyRole(Constants.ClubSuperAdmin, Constants.ClubMod);          

        }

    }
}
