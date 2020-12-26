using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MSFSAddonsHub.WebApi.Controllers
{
    public class Authentication : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        private readonly ILogger<RegisterModel> _logger;

        private readonly MSFSAddonDBContext _context;
        public Authentication(MSFSAddonDBContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<RegisterModel> logger, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }
        [HttpPost]
        [Route("Authentication/RegisterUser")]
        public async Task<IActionResult> RegisterUser(User model)
        {
            List<string> errors = new List<string>();

            string returnUrl = "";
            var user = new ApplicationUser { Id = Guid.NewGuid().ToString(), UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
            //ADD CLAIM HERE!!!!
            returnUrl = returnUrl ?? Url.Content("~/");

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Errors.Count() >= 0)
            {
                foreach (var item in result.Errors)
                    errors.Add(item.Code + " " + item.Description);
                return BadRequest(errors);

            }

            var test = await _userManager.AddClaimAsync(user, new Claim("FullName", user.FirstName + " " + user.LastName));

            await _userManager.AddToRoleAsync(user, "admin");

            if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new
                    {
                        area = "Identity",
                        userId = user.Id,
                        code = code,
                        returnUrl = returnUrl
                    },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>."); ;
                return Ok();
            }
            else
                return BadRequest();
        }


    }
}
