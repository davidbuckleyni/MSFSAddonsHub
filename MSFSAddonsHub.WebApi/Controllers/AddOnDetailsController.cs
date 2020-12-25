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
    public class AddOnDetailsController : Controller
    {
        private readonly MSFSAddonDBContext _context;

        public AddOnDetailsController(MSFSAddonDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("AddOns/GetAll")]
        public IEnumerable<AddOnDetails> GetAllAddonDetails()
        {
            return _context.AddonDetails.ToList();
        }

        [HttpGet]
        [Route("AddOns/GetAllAddonDetailsById")]
        public IEnumerable<AddOnDetails> GetAllAddonDetailsById(int Id)
        {
            return _context.AddonDetails.Where(w=>w.Id==Id &&w.isActive ==true && w.isDeleted==false).ToList();
        }

     
    }
}
