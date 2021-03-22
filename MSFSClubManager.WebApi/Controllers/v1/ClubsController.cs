using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http.Headers;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace MSFSClubManager.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    [Route("v{version:apiVersion}/")]

    public class ClubsController : Controller
    {
        private readonly MSFSClubManagerDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClubsController(IHttpContextAccessor httpContextAccessor, MSFSClubManagerDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;

        }

        [HttpGet]
        [Route("Clubs/GetAllClubs")]
        public async Task<IEnumerable<Club>> GetAllClubs()
        {
            var test = await _context.Clubs.Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();
            return test;
        }

        [HttpGet]
        [Route("Clubs/GetClubDetails")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddon = await _context.Clubs
                .FirstOrDefaultAsync(m => m.Id == id && m.isDeleted == false && m.isActive == true);
            if (userAddon == null)
            {
                return NotFound();
            }

            return View(userAddon);
        }



        // POST: UserAddons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Clubs/Create")]
        public async Task<IActionResult> Create(ClubViewModelApi clubModel)
        {
            if (ModelState.IsValid)
            {
                Club _club = new Club();
                _club.Name = clubModel.Name;
                _club.Description = clubModel.Description;
                _club.isActive = clubModel.isActive;
                _club.isDeleted = clubModel.isDeleted;
                _club.CreatedDate = DateTime.Now;
                //_club.CreatedBy = insert first lastname here;
                var authorization = Request.Headers[HeaderNames.Authorization];

                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    // we have a valid AuthenticationHeaderValue that has the following details:

                    var scheme = headerValue.Scheme;
                    var JWTToken = headerValue.Parameter;

                    var token = new JwtSecurityToken(jwtEncodedString: JWTToken);
                    string name = token.Claims.First(c => c.Type == "CreatedBy").Value;
                    // scheme will be "Bearer"
                    // parmameter will be the token itself.
                    _club.CreatedBy = name;
                }


                _context.Clubs.Add(_club);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return View(clubModel);
        }


        [HttpDelete]
        [Route("Clubs/Delete")]
        public async Task<IActionResult> Delete(ClubViewModelApi clubModel)
        {
            var club = _context.Clubs.Where(w => w.Id == clubModel.ID && w.isDeleted == false && w.isActive == true).FirstOrDefault();
            if (club != null)
            {

                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();

            }


        }
        [HttpPut]
        [Route("Clubs/Put")]
        public async Task<IActionResult> Put(ClubViewModelApi clubModel)
        {

            var club = _context.Clubs.Where(w => w.Id == clubModel.ID && w.isDeleted == false && w.isActive == true).FirstOrDefault();
            if (club != null)
            {
                club.Name = clubModel.Name;
                club.Description = clubModel.Description;
                club.isDeleted = clubModel.isDeleted;
                club.isActive = clubModel.isActive;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        private bool UserAddonExists(int id)
        {
            return _context.Mods.Any(e => e.Id == id);
        }
    }
}
