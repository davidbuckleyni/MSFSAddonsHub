using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSFSAddonsHub.Dal.Models;
using System;

namespace MSFSAddonsHub.Dal
{
    public class MSFSAddonDBContext : IdentityDbContext<IdentityUser>
    {
        public MSFSAddonDBContext(DbContextOptions<MSFSAddonDBContext> options)
        : base(options)
        {
        }
        public DbSet<AddOnDetails> AddonDetails { get; set; }

        public DbSet<AddOnDetails> Category { get; set; }

        public DbSet<Subscriber> Subscriber { get; set; }

 
        public DbSet<DownloadManager> DownloadManager { get; set; }


        public void AddSubscriber (Subscriber sub)

        {
            this.Add(sub);
            this.SaveChanges();

        }
    }
}
