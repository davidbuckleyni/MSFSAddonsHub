using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSFSAddonsHub.Dal;

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
            return View();
        }
    }



}
