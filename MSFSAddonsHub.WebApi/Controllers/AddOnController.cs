using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;

namespace MSFSAddonsHub.WebApi.Controllers
{
    public class AddOnController : Controller
    {
        private readonly MSFSAddonDBContext _context;

        public AddOnController(MSFSAddonDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("AddOns/GetAll")]
        public IEnumerable<MyAddon> GetAllAddonDetails()
        {
            return _context.UserAddons.ToList();
        }

        [HttpGet]
        [Route("AddOns/GetAllAddonDetailsById")]
        public IEnumerable<MyAddon> GetAllAddonDetailsById(int Id)
        {
            return _context.UserAddons.Where(w=>w.Id==Id &&w.isActive ==true && w.isDeleted==false).ToList();
        }

     
    }
}
