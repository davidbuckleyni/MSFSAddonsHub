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

        public BaseController(IHttpContextAccessor httpContextAccessor,MSFSAddonDBContext context, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;

            _context = context;
               _userManager = userManager;
        }

        public string UserId { get; set; }
        protected async Task<string> GetUserId()
        {
            var userId = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name).Result.Id.ToString();
     return (userId);
        }

    }
}
