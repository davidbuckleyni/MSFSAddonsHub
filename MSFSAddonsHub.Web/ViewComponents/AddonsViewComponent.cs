using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSFSAddonsHub.Dal;
using NToastNotify.Helpers;

namespace MSFSAddonsHub.Web.ViewComponents
{
    [ViewComponent(Name = "AddonsView")]
    public class AddonsViewComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly MSFSAddonDBContext db;


        public AddonsViewComponent(MSFSAddonDBContext context)
        {
            db = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {


            var test = db.Mods.Where(w => w.isActive == true && w.isDeleted == false).OrderBy(o => o.Version)
                .ToList();

            return View(test);
        }
    }



}
