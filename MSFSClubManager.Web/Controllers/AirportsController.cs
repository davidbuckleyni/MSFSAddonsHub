using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Models;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;

namespace MSFSClubManager.Web.Controllers
{
    public class AirportsController : Controller
    {
        private readonly MSFSClubManagerDBContext _context;

        public AirportsController(MSFSClubManagerDBContext context)
        {
            _context = context;
        }

        // GET: Airports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Airport.ToListAsync());
        }

        // GET: Airports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airPorts = await _context.Airport.FirstOrDefaultAsync(m => m.Id == id);
            if (airPorts == null)
            {
                return NotFound();
            }

            return View(airPorts);
        }

        // GET: Airports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Airports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ICAO,Name,City,State,LongX,LatY,Version,isActive,isDeleted,CreatedDate,CreatedBy")] AirPortsViewModel airPorts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(airPorts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(airPorts);
        }

        // GET: Airports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airPorts = await _context.Airport.FindAsync(id);
            if (airPorts == null)
            {
                return NotFound();
            }
            return View(airPorts);
        }

        // POST: Airports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ICAO,Name,City,State,LongX,LatY,Version,isActive,isDeleted,CreatedDate,CreatedBy")] AirPortsViewModel airPorts)
        {
            if (id != airPorts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(airPorts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AirPortsExists(airPorts.Id))
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
            return View(airPorts);
        }

        // GET: Airports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var airPorts = await _context.Airport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (airPorts == null)
            {
                return NotFound();
            }

            return View(airPorts);
        }

        // POST: Airports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var airPorts = await _context.Airport.FindAsync(id);
            _context.Airport.Remove(airPorts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AirPortsExists(int id)
        {
            return _context.Airport.Any(e => e.Id == id);
        }
    }
}
