using Microsoft.AspNetCore.Identity;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Web.Helpers
{
    public static class HelperMethods
    {
        public static async Task<IdentityResult> DeleteUserAccount(UserManager<ApplicationUser> userManager,
                                                                        string userEmail, MSFSAddonDBContext context)
        {
            IdentityResult rc = new IdentityResult();

            if ((userManager != null) && (userEmail != null) && (context != null))
            {
                var user = await userManager.FindByEmailAsync(userEmail);
            var rolesForUser = await userManager.GetRolesAsync(user);

                using (var transaction = context.Database.BeginTransaction())
                {
                  
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await userManager.RemoveFromRoleAsync(user, item);
                        }
                    }
                    rc = await userManager.DeleteAsync(user);
                    transaction.Commit();
                }
            }
            return rc;
        }
        public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(principal.IsInRole);
        }
    }
}
