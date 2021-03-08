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
    public class ModsController : Controller
    {
        private readonly MSFSAddonDBContext _context;

        public ModsController(MSFSAddonDBContext context)
        {
            _context = context;
        }

        // GET: UserAddons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mods.ToListAsync());
        }

        // GET: UserAddons/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("Id,AddONId,TeannatId,Name,ThumbNail,isActive,isDeleted,CreatedDate,CreatedBy")] UserAddonViewModel userAddon)
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
            var usrMod = await _context.Mods.FindAsync(id);
            _context.Mods.Remove(usrMod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAddonExists(int id)
        {
            return _context.Mods.Any(e => e.Id == id);
        }
    }
}
