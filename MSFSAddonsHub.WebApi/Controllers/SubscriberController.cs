using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSFSAddonsHub.WebApi.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly MSFSAddonDBContext _context;
        public SubscriberController(MSFSAddonDBContext context)
        {

            _context = context;
        }
        [HttpPost]
        [Route("Subscriber/AddSubscriber")]
        [Authorize]
        public async Task<IActionResult> AddSubscriber(SubscriberViewModel subVm)
        
        {
            try
            {
                Subscriber sub = new Subscriber();
                sub.Email = subVm.Email;
                sub.GpdrRemoval = false;

                _context.AddSubscriber(sub);
                await _context.SaveChangesAsync();

            }
            catch(Exception EX)
            {
                return BadRequest(new { message = "Cannot add subscriber to database " + EX.ToString() }) ;
 


            }
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
