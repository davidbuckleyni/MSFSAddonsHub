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
        public async Task<IActionResult> Profile(Guid Id)
        {
            _toast.AddWarningToastMessage("This is a test to see this works");

            return View(await _context.MyDashBoard.Where(w=>w.UserId== Id && w.isActive==true && w.isDeleted==false ).FirstOrDefaultAsync());
        }

        public async Task<IActionResult> MyAddons(Guid Id)
        {
            _toast.AddWarningToastMessage("This is a test to see this works");

            return View(await _context.UserAddons.Where(w => w.UserId == Id && w.isActive == true && w.isDeleted == false).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Type,TeannatId,FirstName,LastName,AboutMe")] MyDashBoardViewModel myProfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myProfile);
        }

        /// <summary>
        /// Handles all saves the controllers will all have a submit functon which will pass the view model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  IActionResult Submit(MyDashBoardViewModel profile)
        {


            return View();
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
            return View();
        }

      
    }
}
