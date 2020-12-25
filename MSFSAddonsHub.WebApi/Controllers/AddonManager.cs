using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSFSAddonsHub.Dal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSAddonsHub.WebApi.Controllers
{
    public class AddonManager : Controller
    {
        private readonly MSFSAddonDBContext _context;
        public AddonManager(MSFSAddonDBContext context)
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
