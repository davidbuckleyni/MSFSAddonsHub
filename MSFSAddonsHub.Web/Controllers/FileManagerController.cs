using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using CG.Web.MegaApiClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MSFSAddons.Models;
using MSFSAddons.Models.Models;
using MSFSAddons.Models.ViewModels;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using MSFSAddonsHub.FL;
using NToastNotify;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MSFSAddonsHub.Web.Controllers
{
    public class FileManagerController : BaseController
    {
        private readonly IHostingEnvironment hostingEnvironment;

        private readonly MSFSAddonDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

         private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }
        public FileManagerController(IHttpContextAccessor httpContextAccessor, MSFSAddonDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, IHostingEnvironment environment, IOptions<AppSettings> appSettings
) : base(httpContextAccessor, context, userManager)
        {
            hostingEnvironment = environment;

            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
            _toast = toast;
            _appSettings = appSettings.Value;
        
           
        }
        [Route("MyDashBoard/FileManager")]
        // GET: FileManger
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileManager.ToListAsync());
        }

        // GET: FileManger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileManger = await _context.FileManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileManger == null)
            {
                return NotFound();
            }

            return View(fileManger);
        }

        // GET: FileManger/Create
        public IActionResult Create()
        {
            return View();
        }
        

      [Route("/MyDashBoard/FileManager/Upload")]
        public IActionResult Upload(FileManagerViewModel fileManager)
        {
            return View();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]        
    public async Task<IActionResult> UploadFiles([FromForm]FileManagerViewModel fileManager)
    {
        var uploads = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
        string uploadsUserId = uploads + @"\" + UserId.ToString() + @"\";

        if (!Directory.Exists(uploadsUserId))
            Directory.CreateDirectory(uploadsUserId);
             

        foreach (IFormFile formFile in fileManager.File)
        {



            string fullFile = uploads + @"\" + UserId.ToString() + @"\" + formFile.FileName;
            using (var stream = new FileStream(fullFile, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            if (ModelState.IsValid)
            {

                var userName = _appSettings.MegaUserName;
                var password = _appSettings.MegaPassword;
                FileClient client = new FileClient();
                FileInfo info = new FileInfo(formFile.FileName);
                var remoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
                await client.UploadFileAsync(_context, userName, password, fullFile, info.Extension.ToLower(), UserId.ToString(), remoteIpAddress.ToString());
            }

        }
        return View("~/Views/FileManager/Index.cshtml", _context.FileManager.Where(w => w.UserId == UserId).ToList());
    }
            // POST: FileManger/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConflictId,ThumbNail,Version,DownloadLink,TotalDownloads,DownloadUrl,canBeDownloadedByOtherUsers,FileExtension,isZipFile,isJsonFile,DownloadJson,TeannatId,UserId,isDisplayHomePage,isFeatured,ThumbNailPath,FilePath,isActive,isDeleted,IPAddressBytes,CreatedDate,CreatedBy")] FileManger fileManger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileManger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileManger);
        }

        // GET: FileManger/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileManger = await _context.FileManager.FindAsync(id);
            if (fileManger == null)
            {
                return NotFound();
            }
            return View(fileManger);
        }

        // POST: FileManger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConflictId,ThumbNail,Version,DownloadLink,TotalDownloads,DownloadUrl,canBeDownloadedByOtherUsers,FileExtension,isZipFile,isJsonFile,DownloadJson,TeannatId,UserId,isDisplayHomePage,isFeatured,ThumbNailPath,FilePath,isActive,isDeleted,IPAddressBytes,CreatedDate,CreatedBy")] FileManger fileManger)
        {
            if (id != fileManger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileManger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileMangerExists(fileManger.Id))
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
            return View(fileManger);
        }

        // GET: FileManger/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileManger = await _context.FileManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fileManger == null)
            {
                return NotFound();
            }

            return View(fileManger);
        }

        // POST: FileManger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileManger = await _context.FileManager.FindAsync(id);
            _context.FileManager.Remove(fileManger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileMangerExists(int id)
        {
            return _context.FileManager.Any(e => e.Id == id);
        }
    }
}
