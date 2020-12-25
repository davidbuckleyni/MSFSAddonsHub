using Microsoft.EntityFrameworkCore;
using MSFSAddonsHub.Dal.Models;
using System;

namespace MSFSAddonsHub.Dal
{
    public class MSFSAddonDBContext :DbContext
    {
        public MSFSAddonDBContext(DbContextOptions<MSFSAddonDBContext> options)
        : base(options)
        {
        }
        public DbSet<AddOnDetails> AddonDetails { get; set; }

        public DbSet<AddOnDetails> Category { get; set; }


    public DbSet<DownloadManager> DownloadManager { get; set; }
    }
}
