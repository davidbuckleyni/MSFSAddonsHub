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
using MSFSClubManager.Models;
using MSFSClubManager.Models.Models;
using MSFSClubManager.Dal.ViewModels;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using MSFSClubManager.FL;
using NToastNotify;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MSFSClubManager.Web.Controllers
{
    public class FileManagerController : BaseController
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private IConfiguration _configRoot;


        private readonly MSFSClubManagerDBContext _context;
        private readonly IToastNotification _toast;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public string userName { get; set; }
        private RoleManager<IdentityRole> roleManager;

        public FileManagerController(IHttpContextAccessor httpContextAccessor, MSFSClubManagerDBContext context, UserManager<ApplicationUser> userManager, IToastNotification toast, IHostingEnvironment environment, IOptions<AppSettings> appSettings, IConfiguration configRoot, RoleManager<IdentityRole> roleMgr
) : base(httpContextAccessor, context, userManager,roleMgr)
        {
            hostingEnvironment = environment;
            _configRoot = (IConfigurationRoot)configRoot;
            roleManager = roleMgr;


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
            return View(await _context.FileManager.Where(w => w.UserId == UserId && w.isActive == true && w.isDeleted == false).ToListAsync());
        }

        // GET: FileManger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileManger = await _context.FileManager
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId==UserId && m.isDeleted==false && m.isActive==true);
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
        public  enum FileManagerUploadTypeEnum{
            FTP=1,
            Mega=2
            }
        public string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        [HttpGet("download")]
        public IActionResult DownloadFile([FromQuery] string link)
        {

            var record = _context.FileManager.Where(w => w.HttpDownloadUrl == link && w.UserId == UserId && w.isActive == true && w.isDeleted == false).FirstOrDefault();
            return PhysicalFile(record.HttpDownloadUrl, GetMimeType(record.HttpDownloadUrl), Path.GetFileName(record.HttpDownloadUrl));

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
                FileInfo info = new FileInfo(formFile.FileName);
                string destFilename = fullFile;
                var remoteIpAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
                    if (fileManager.UploadServiceType ==(int) FileManagerUploadTypeEnum.Mega)
                    {
                        MegaUploadFileClient client = new MegaUploadFileClient();

                        await client.UploadFileAsync(_context, userName, password, fullFile, destFilename, info.Extension.ToLower(), UserId.ToString(), remoteIpAddress.ToString());
                    }
                    if (fileManager.UploadServiceType == (int)FileManagerUploadTypeEnum.FTP)
                    {
                        CloudTBFtpClient client = new CloudTBFtpClient(_appSettings, CloudTBFtpClient.FtpTypeEnum.Ftp);
                        await client.UploadFileAsync(_context, userName, password, fullFile,destFilename, info.Extension.ToLower(), UserId.ToString(), remoteIpAddress.ToString());
                    }

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
