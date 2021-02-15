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

namespace MSFSAddonsHub.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly MSFSAddonDBContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private MSFSAddonDBContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BaseController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;

            _context = context;
            _userManager = userManager;
            GetUserId();
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

        public bool isClubAdmin { get; set; }
        private  bool isCurrentUserClubAdmin()
        {

            var clubId = Convert.ToInt32(Request.Cookies["ClubId"]);
            isClubAdmin= _context.ClubUsers.Any(w => w.User.Id == UserId.ToString() && w.ClubId== clubId && w.Role.Name.Contains("ClubSuperAdmin"));
            return isClubAdmin;


        }

    }
}
