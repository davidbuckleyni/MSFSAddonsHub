using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Web.Helpers
{
    public static class HelperMethods
    {

        public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(principal.IsInRole);
        }
    }
}
