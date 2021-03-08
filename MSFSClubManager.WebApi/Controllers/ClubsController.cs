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

namespace MSFSClubManager.WebApi.Controllers
{
    public class ClubsController : Controller
    {
        private readonly MSFSClubManagerDBContext _context;

        public ClubsController(MSFSClubManagerDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Clubs/GetAllClubs")]
        public async Task<IEnumerable<Club>> GetAllClubs()        {
            return await _context.Clubs.Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();
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
                .FirstOrDefaultAsync(m => m.Id == id && m.isDeleted==false && m.isActive==true);
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
        [Route("Clubs/Create")]
        public async Task<IActionResult> Create(ClubViewModel clubModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clubModel);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAddon = await _context.Clubs.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,AddONId,TeannatId,Name,ThumbNail,isActive,isDeleted,CreatedDate,CreatedBy")] UserAddonViewModel userAddon)
        {
            if (id != userAddon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAddon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAddonExists(userAddon.Id))
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
            return View(userAddon);
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
