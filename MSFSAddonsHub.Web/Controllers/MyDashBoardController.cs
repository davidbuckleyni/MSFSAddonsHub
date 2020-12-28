using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using NToastNotify;

namespace MSFSAddonsHub.Web.Controllers
{
    public class MyDashBoardController : Controller
    {
        private readonly MSFSAddonDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;
        public MyDashBoardController(MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast)
        {

            _context = context;
            _userManager = userManager;
            _toast = toast;
        }

        // GET: MyProfile
        public async Task<IActionResult> Index()
        {
            _toast.AddWarningToastMessage("This is a test to see this works");

            return View(await _context.MyDashBoard.ToListAsync());
        }

        // GET: MyProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProfile = await _context.MyDashBoard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myProfile == null)
            {
                return NotFound();
            }

            return View(myProfile);
        }

        // GET: MyProfile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyProfile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,TeannatId,FirstName,LastName,AboutMe")] MyDashBoard myProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myProfile);
        }

        // GET: MyProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProfile = await _context.MyDashBoard.FindAsync(id);
            if (myProfile == null)
            {
                return NotFound();
            }
            return View(myProfile);
        }

        // POST: MyProfile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,TeannatId,FirstName,LastName,AboutMe")] MyDashBoard myDashBoard)
        {
            if (id != myDashBoard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myDashBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyProfileExists(myDashBoard.Id))
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
            return View(myDashBoard);
        }

        // GET: MyProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProfile = await _context.MyDashBoard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myProfile == null)
            {
                return NotFound();
            }

            return View(myProfile);
        }

        // POST: MyProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myProfile = await _context.MyDashBoard.FindAsync(id);
            _context.MyDashBoard.Remove(myProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyProfileExists(int id)
        {
            return _context.MyDashBoard.Any(e => e.Id == id);
        }
    }
}
