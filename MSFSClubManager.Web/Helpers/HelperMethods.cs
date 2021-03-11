using Microsoft.AspNetCore.Identity;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MSFSClubManager.Web.Helpers
{
    public static class HelperMethods
    {
        public static async Task<IdentityResult> DeleteUserAccount(UserManager<ApplicationUser> userManager,
                                                                        string userEmail, MSFSClubManagerDBContext context)
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

        public static string SanitizeclubName(string clubName, char replacementChar = '_')
        {
            var blackList = new HashSet<char>(System.IO.Path.GetInvalidFileNameChars());
            var output = clubName.ToCharArray();
            for (int i = 0, ln = output.Length; i < ln; i++)
            {
                if (blackList.Contains(output[i]))
                {
                    output[i] = replacementChar;
                }
            }
            return new String(output);
        }
        public static bool IsInAnyRole(this ClaimsIdentity principal, params string[] roles)
        {
            foreach (var role in roles)
            {
                if (principal.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == role))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
