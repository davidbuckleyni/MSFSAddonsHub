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
using MSFSAddons.Dal.ViewModels;
using MSFSAddons.Models;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using MSFSAddonsHub.Web.Helpers;
using NToastNotify;

namespace MSFSAddonsHub.Web.Controllers
{
    public class ClubsController : BaseController
    {
        private readonly MSFSAddonDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }

        private RoleManager<IdentityRole> roleManager;



        public ClubsController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
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
           var test =_context.Clubs;
            var clubs =  _context.Clubs.Where(w => w.isActive == true && w.isDeleted == false).ToList();

            ClubsViewModel clubViewModel = new ClubsViewModel();
            clubViewModel.Clubs = clubs;


            return View(clubViewModel);
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

            var club = await _context.Clubs
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
        public async Task<IActionResult> Create([Bind("Id,TeannatId,UserId,Name,Description,Url,Logo,ThumbNail,BannedTime,BanPeriod,isBanned,isActive,isDeleted,CreatedDate,CreatedBy")] Club club)
        {
            if (ModelState.IsValid)
            {


                club.TeannatId = GetTennantId().Result;
                club.ClubId = Guid.NewGuid();
                club.isActive = true;
                club.isDeleted = false;
                _context.Add(club);
                await _context.SaveChangesAsync();

                ClubMembers clubMembers = new ClubMembers();

                clubMembers.UserId = UserId.ToString();
                clubMembers.ClubId = club.Id;
                clubMembers.RoleId = "f2f2b605-6f0b-4e83-87c1-a28c25e768a1";
                clubMembers.isActive = true;
                clubMembers.isDeleted = false;

                _context.ClubMembers.Add(clubMembers);
                await _context.SaveChangesAsync();

                _toast.AddSuccessToastMessage("Club Created");

                return RedirectToAction(nameof(Index));

            }
            return View(club);
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

            var club = await _context.Clubs.FindAsync(id);
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
        public async Task<IActionResult> Submit(int id, [Bind("Id,TeannatId,UserId,Name,Description,Url,Logo,ThumbNail,BannedTime,BanPeriod,isBanned,isActive,isDeleted,CreatedDate,CreatedBy")] Club club)
        {
            ClubsViewModel clubViewModel = new ClubsViewModel();


            //when we are submitting a new record we wont have an id we need to trap for this.

            //only admin and aboves should be allowed ot create a club even mods are not
            if (User.IsInAnyRole(Constants.ClubUser,Constants.ClubMod) )
            {


                ModelState.AddModelError("Error", "A Club user cannot create a club");
                ClubViewModel clubView = new ClubViewModel();
                clubView.Club = club;
                return View("CreateOrEdit", clubView);

            }
            User.IsInRole("ClubMod");
             if(club.Id==0)
                ModelState.Remove("Club.Id");

            if (ModelState.IsValid)
            {
                try
                {


                    //if id = zero we always want to create a new club
                    if (id == 0)
                    {



                        club.UserId = UserId;
                        club.isActive = true;
                        club.isDeleted = false;
                        club.CreatedDate = DateTime.Now;
                        club.CreatedBy = await GetUserName();
                        _context.Clubs.Add(club);
                        await _context.SaveChangesAsync();
                        clubViewModel.Clubs = await _context.Clubs.Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();


                        ClubMembers clubMembers = new ClubMembers();

                        clubMembers.User = AppUser;
                        clubMembers.UserId = UserId.ToString();

                        clubMembers.isActive = true;
                        clubMembers.isDeleted = false;
                        clubMembers.CreatedBy = await GetUserName();
                        clubMembers.CreatedDate = DateTime.Now;

                        //check if club members 
                        var clubMembersCount = _context.ClubMembers.Where(w => w.Club.Name == club.Name && w.Role.Id == Constants.ClubSuperAdmin).GroupBy(c => c.Club.Name).Where(w => w.Count() > 1).ToListAsync();
                        IdentityRole role = await roleManager.FindByIdAsync(Constants.ClubSuperAdmin);
                        clubMembers.Role = role;
                        clubMembers.RoleId = role.Id;
                        clubMembers.ClubId = club.Id;
                        _context.ClubMembers.Add(clubMembers);
                        await _context.SaveChangesAsync();
                        _toast.AddSuccessToastMessage($"Club created {club.Name})");

                        return View("~/Views/Clubs/Index.cshtml", clubViewModel);

                    }
                    else
                    {

                        _context.Update(club);
                        await _context.SaveChangesAsync();
                        _toast.AddSuccessToastMessage($"Club Updated {club.Name})");

                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.Id))
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
                ClubViewModel clubView = new ClubViewModel();
                clubView.Club = club;
                return View("CreateOrEdit", clubView);
            }


           
            
            


        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
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
            var club = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}
