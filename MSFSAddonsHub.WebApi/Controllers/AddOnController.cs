﻿using System;
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
        public IEnumerable<Mods> GetAllAddonDetails()
        {
            return _context.Mods.ToList();
        }

        [HttpGet]
        [Route("AddOns/GetAllAddonDetailsById")]
        public IEnumerable<Mods> GetAllAddonDetailsById(int Id)
        {
            return _context.Mods.Where(w=>w.Id==Id &&w.isActive ==true && w.isDeleted==false).ToList();
        }

     
    }
}
