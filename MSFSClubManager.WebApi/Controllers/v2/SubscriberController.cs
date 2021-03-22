using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSFSClubManager.WebApi.Controllers
{
    [ApiVersion("2")]
    [ApiController]
    [Route("v{version:apiVersion}/")]


    public class SubscriberController : Controller
    {
        private readonly MSFSClubManagerDBContext _context;
        public SubscriberController(MSFSClubManagerDBContext context)
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

       
    }
}
