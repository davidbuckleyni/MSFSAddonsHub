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
using MSFSAddons.Models;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using NToastNotify;

namespace MSFSAddonsHub.Web.Controllers
{
    public class ClubMembersController : BaseController
    {
        private readonly MSFSAddonDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }



        public ClubMembersController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast) : base(httpContextAccessor, context, userManager)
        {


            _context = context;
            _userManager = userManager;
            _toast = toast;

            userName = GetUserName().Result.ToString();
            ViewBag.UserName = userName;
        }
        /// <summary>
        /// Admin Managment page for the clubs
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Manage()
        {
            return View();
        }

        public async Task<IActionResult> ClubRoles()
        {
            var query = await _context.ClubUsers.Include(c => c.Role).Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();

            return View(query);

        }
        public async Task<IActionResult> Index()
        {
            var tennantId = GetTennantId().Result;
            Guid.TryParse(UserId.ToString().ToUpper(), out Guid guidResult);

            var club = await _context.ClubUsers.Include(c => c.Role).Include(c => c.User).Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();

            var clubSql = _context.ClubUsers.Include(c => c.Role).Include(c => c.User).Where(w => w.isActive == true && w.isDeleted == false).ToQueryString();
            return View(club);
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
                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {

       
            // 
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.ClubUsers.Include(c => c.Role).Include(c => c.User).Where(w => w.User.Id == id).FirstOrDefaultAsync();
           await  PopulateViewBags();

            var userRolesNotIn = _context.ClubUsers.Include(c => c.Role).Where(w => w.User.Id == id).ToList();
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        public async  Task<int> PopulateViewBags()
        {


            var clubRoles = _context.Roles.Where(w => w.Name.Contains("Club")).ToList();

            ViewBag.ClubRoles = clubRoles;
            var result = 2;
            return result;
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ClubUsers clubUsers)
        {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(clubUsers);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ClubExists(clubUsers.Id))
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
        
           await  PopulateViewBags();
            return View(@"~/Views/ClubMembers/Edit.cshtml", clubUsers);
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

        private bool ClubExists(int? id)
        {
            return _context.Clubs.Any(e => e.Id == id);
        }
    }
}
