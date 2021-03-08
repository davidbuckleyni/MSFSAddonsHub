using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Dal;
using NToastNotify.Helpers;

namespace MSFSClubManager.Web.ViewComponents
{
    [ViewComponent(Name = "DownloadsView")]

    public class DownloadsViewComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly MSFSClubManagerDBContext db;


        public DownloadsViewComponent(MSFSClubManagerDBContext context)
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
