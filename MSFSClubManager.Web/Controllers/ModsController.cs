using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using NToastNotify;

namespace MSFSClubManager.Web.Controllers
{
    public class ModsController : BaseController
    {
        private readonly MSFSAddonDBContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private MSFSAddonDBContext context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private RoleManager<IdentityRole> roleManager;

        public ModsController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr) : base(httpContextAccessor, context, userManager, roleMgr)
        {
            roleManager = roleMgr;

  

            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
            _context = context;
        }


        public async Task<IActionResult> MyDownloads()
        {
            return View(await _context.Mods.Where(w => w.UserId == UserId).ToListAsync());
        }

        // GET: UserAddons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mods.ToListAsync());
        }

        // GET: UserAddons/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddon = await _context.Mods
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userAddon == null)
            {
                return NotFound();
            }

            return View(userAddon);
        }

        // GET: UserAddons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAddons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AddONId,TeannatId,Name,Description,ConflictId,ThumbNail,Version,TotalDownloads,DownloadUrl,isZipFile,isJsonFile,DownloadJson,Category,isDisplayHomePage,isFeatured,isActive,isDeleted,CreatedDate,CreatedBy")] Mods userAddon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAddon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAddon);
        }

        // GET: UserAddons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddon = await _context.Mods.FindAsync(id);
            if (userAddon == null)
            {
                return NotFound();
            }
            return View(userAddon);
        }

        // POST: UserAddons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserAddonId,AddONId,TeannatId,Name,Description,ConflictId,ThumbNail,Version,TotalDownloads,DownloadUrl,isZipFile,isJsonFile,DownloadJson,Category,isDisplayHomePage,isFeatured,isActive,isDeleted,CreatedDate,CreatedBy")] Mods userMods)
        {
            if (id != userMods.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userMods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAddonExists(userMods.Id))
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
            return View(userMods);
        }

        // GET: UserAddons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddon = await _context.Mods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAddon == null)
            {
                return NotFound();
            }

            return View(userAddon);
        }

        // POST: UserAddons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAddon = await _context.Mods.FindAsync(id);
            _context.Mods.Remove(userAddon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAddonExists(int id)
        {
            return _context.Mods.Any(e => e.Id == id);
        }
    }
}
