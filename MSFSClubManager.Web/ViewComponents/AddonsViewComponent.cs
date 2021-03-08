using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSFSClubManager.Dal;
using NToastNotify.Helpers;

namespace MSFSClubManager.Web.ViewComponents
{
    [ViewComponent(Name = "AddonsView")]
    public class AddonsViewComponent : ViewComponent
    {

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly MSFSClubManagerDBContext db;


        public AddonsViewComponent(MSFSClubManagerDBContext context)
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
