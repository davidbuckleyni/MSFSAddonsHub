using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSFSAddons.Models;
using MSFSAddons.ViewModels;
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
        private RoleManager<IdentityRole> roleManager;

        private readonly IEmailSender _emailSender;


        public ClubMembersController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, RoleManager<IdentityRole> roleMgr, IEmailSender emailSender) : base(httpContextAccessor, context, userManager, roleMgr)
        {
            roleManager = roleMgr;

            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
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
            var query = await _context.ClubMembers.Include(c => c.Role).Where(w => w.isActive == true && w.isDeleted == false).ToListAsync();

            return View(query);

        }
        public async Task<IActionResult> Index(int? id)
        {
            List<ClubMembers> clubsMembers = new List<ClubMembers>();
            Guid.TryParse(UserId.ToString().ToUpper(), out Guid guidResult);
            
            if (id == null)
                clubsMembers = await _context.ClubMembers.Where(w => w.isActive == true && w.isDeleted == false).Include(c => c.Club).Include(c => c.Role).Include(c => c.User).ToListAsync();
            else
                clubsMembers = await _context.ClubMembers.Where(w => w.ClubId == id && w.isActive == true && w.isDeleted == false).Include(c => c.Club).Include(c => c.Role).Include(c => c.User).ToListAsync();


            var clubSql = _context.ClubMembers.Where(w => w.ClubId == id && w.isActive == true && w.isDeleted == false).Include(c => c.Club).Include(c => c.Role).Include(c => c.User).ToQueryString();


            ClubMembersViewModal clubMembersViewModal = new ClubMembersViewModal();
            clubMembersViewModal.ClubMembers = clubsMembers;
            
            clubMembersViewModal.ClubInvitesViewModal = new ClubInvitesViewModel();
            clubMembersViewModal.ClubInvitesViewModal.ClubId = ClubId;
            clubMembersViewModal.ClubInvitesViewModal.FromMember = Email;
            clubMembersViewModal.ClubInvitesViewModal.ToMember = "davidbuckleyweb@gmail.com";

            return View(clubMembersViewModal);
        }


        public async Task<IActionResult> Invites(ClubInvitesViewModel invites)
        {
            try
            {

                var memberSendingInvite = await _userManager.FindByEmailAsync(invites.FromMember);
                var memberInviteBeingSentTo = await _userManager.FindByEmailAsync(invites.ToMember);


                string html = "<table width=\"100 %\" cellspacing=\"0\" cellpadding=\"0\">";
                html = html + "<tr>";
                html = html + "<td>";

                html = html + "<table cellspacing = \"0\" cellpadding = \"0\" >";
                html = html + "<tr>";

                html = html + "< td class=\"button\" bgcolor=\"#ED2939\">";
                html = html + "<a class=\"link\" href=\"https://www.msfsaddonshub.com/out/Invites" + ">";
                html = html + "Accept Invite</a>";
                html = html + "</table>";
                html = html + "</td></tr></table>";


                await _emailSender.SendEmailAsync(invites.ToMember, "Club invite", html);

                ClubInvites invitesRecord = new ClubInvites();
                Guid.TryParse(memberSendingInvite.Id, out Guid resultMemeberId);
                invitesRecord.UserId = resultMemeberId;
                invitesRecord.UserFrom = memberSendingInvite;
                invitesRecord.ClubId = invites.ClubId;
                invitesRecord.UserTo = memberInviteBeingSentTo;
                invitesRecord.FromEmail = invites.FromMember;
                invitesRecord.ToEmail = invites.ToMember;
                invitesRecord.Status = (int)ClubInvites.InviteEnum.Sent;
                _context.ClubInvites.Add(invitesRecord);
                await _context.SaveChangesAsync();




                _toast.AddSuccessToastMessage("Club Invite sent , they should recieve email shortly.");




            }
            catch (Exception ex)
            {


            }

            return View();


        }



        // GET: ClubsMembers/Details/5
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

        // GET: ClubsMembers/Create
        public async Task<IActionResult> Create()
        {
            var clubMembers = await _context.ClubMembers.Include(c => c.Role).ToListAsync();


            return View(clubMembers);
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

            var club = await _context.ClubMembers.Include(c => c.Role).Include(c => c.User).Where(w => w.User.Id == id).FirstOrDefaultAsync();

            var userRolesNotIn = _context.ClubMembers.Include(c => c.Role).Where(w => w.User.Id == id).ToList();
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
        public async Task<IActionResult> Edit([Bind("Id,ClubId,Club,RoleId,UserId,BannedStartDateTime,BannedEndDateTime,isBanned,isActive")] ClubMembers clubUsers)
        {
            IdentityRole role = await roleManager.FindByIdAsync(clubUsers.RoleId);
            ApplicationUser? user = _userManager.Users.Where(w => w.Id == clubUsers.UserId).FirstOrDefault();

            clubUsers.Role = role;
            clubUsers.User = user;
            var test = clubUsers;

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
