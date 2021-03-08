using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSFSClubManager.Dal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSClubManager.WebApi.Controllers
{
    public class AddonManagerController : Controller
    {
        private readonly MSFSClubManagerDBContext _context;
        public AddonManagerController(MSFSClubManagerDBContext context)
        {
            _context = context;
        }


        [HttpPut]
        [Route("AddonManager/Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest();
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                //var img = new Entities.Image
                //{
                //    Name = file.FileName,
                //    ContentType = file.ContentType,
                //    Data = ms.ToArray()

                //};
              //  await _repo.CreateImage(img);
                return Ok();
            }
        }
    }
}
