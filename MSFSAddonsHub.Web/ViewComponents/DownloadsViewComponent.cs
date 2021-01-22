using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSFSAddonsHub.Dal;
using NToastNotify.Helpers;

namespace MSFSAddonsHub.Web.ViewComponents
{
    [ViewComponent(Name = "DownloadsView")]

    public class DownloadsViewComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly MSFSAddonDBContext db;


        public DownloadsViewComponent(MSFSAddonDBContext context)
        {
            db = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            var results =await db.FileManager.Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();
            return View(results);

        }
    }
}
