using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Models;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using MSFSClubManager.Web.Helpers;
using NToastNotify;

namespace MSFSClubManager.Web.Controllers
{
    public class FlightsController : BaseController
    {
        private readonly MSFSClubManagerDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }

        private RoleManager<IdentityRole> roleManager;



        public FlightsController(IHttpContextAccessor httpContextAccessor, MSFSClubManagerDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
        {
            roleManager = roleMgr;

            _context = context;
            _userManager = userManager;
            _toast = toast;
            _httpContextAccessor = httpContextAccessor;

            userName = GetUserName().Result.ToString();
            ViewBag.UserName = userName;
        }

        public async Task<IActionResult> ClubRoles()
        {
            var query = await _context.ClubMembers.Include(c => c.Role).Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();

            return View(query);

        }

    
        public async Task<IActionResult> Index()
        {
            var test = _context.Clubs;
            var clubs = _context.Clubs.Where(w => w.UserId == UserId && w.isActive == true && w.isDeleted == false).ToList();
            ClubsViewModel clubViewModel = new ClubsViewModel();
            clubViewModel.Clubs = clubs;
              var userRoles = roleManager.Roles.ToList();

            return View(clubViewModel);
        }

        public ClubsViewModel PopulateViewModel()
        {
            var clubs = _context.Clubs.Where(w => w.UserId == UserId && w.isActive == true && w.isDeleted == false).ToList();
            ClubsViewModel clubViewModel = new ClubsViewModel();
            clubViewModel.Clubs = clubs;
                var userRoles = roleManager.Roles.ToList();
            return clubViewModel;
        }


        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            ClubViewModel clubViewModel = new ClubViewModel();


            if (id == 0)
                return View(new ClubViewModel());
            else
            {
                var clubs = await _context.Clubs.FindAsync(id);
                try
                {
                    clubViewModel.Club = clubs;
                    return View(clubViewModel);
                }
                catch (Exception ex)

                {
                }
                if (clubViewModel == null)
                {
                    return NotFound();
                }
            }



            return View(clubViewModel);
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == UserId && m.isActive == true && m.isDeleted == false);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Flight flight)
        {
            if (ModelState.IsValid)
            {


                flight.isActive = true;
                flight.isDeleted = false;
                _context.Add(flight);
                await _context.SaveChangesAsync();               

                _toast.AddSuccessToastMessage("Flight Created");

                return RedirectToAction(nameof(Index));

            }
            return View(flight);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var option = new CookieOptions();
            option.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("ClubId", id.ToString(), option);

            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Flights.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(Flight flight)
        {
            FlightsViewModel FlightsViewModel = new FlightsViewModel();


            //when we are submitting a new record we wont have an id we need to trap for this.

            //only admin and aboves should be allowed ot create a club even mods are not
            if (((System.Security.Claims.ClaimsIdentity)User.Identity).IsInAnyRole(Constants.ClubSuperAdmin, Constants.ClubAdmin))
            {


                ModelState.AddModelError("Error", "A Club user cannot create a club");
                var flights = _context.Flights.Where(w => w.UserId == UserId && w.isActive == true & w.isDeleted == false).ToList();
                FlightsViewModel flightView = new FlightsViewModel();
                flightView.Flights = flights;
                return View("CreateOrEdit", FlightsViewModel);

            }
            User.IsInRole("ClubMod");
            if (flight.Id == 0)
                ModelState.Remove("Flight.Id");

            if (ModelState.IsValid)
            {
                try
                {
                    var flights = _context.Flights.Where(w => w.UserId == UserId && w.isActive == true & w.isDeleted == false).ToList();
                    FlightsViewModel flightsViewModel = new FlightsViewModel();
                    flightsViewModel.Flights = flights;
                
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightsExists(flight.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            else

            {
                var flights = _context.Flights.Where(w => w.UserId == UserId && w.isActive == true & w.isDeleted == false).ToList();

                FlightsViewModel flightsViewModel = new FlightsViewModel();
                  flightsViewModel.Flights = flights;
                return View("CreateOrEdit", flightsViewModel);
            }







        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Flights
                .FirstOrDefaultAsync(m => m.Id == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flights = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flights);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightsExists(int id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
