﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;

namespace MSFSAddonsHub.Dal
{
    public class MSFSAddonDBContext : IdentityDbContext<ApplicationUser>
    {
        public MSFSAddonDBContext(DbContextOptions<MSFSAddonDBContext> options)
        : base(options)
        {
        }
        public DbSet<Addons> Addons{ get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Subscriber> Subscriber { get; set; }

 
        public DbSet<DownloadManager> DownloadManager { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public void AddSubscriber (Subscriber sub)

        {
            this.Add(sub);
            this.SaveChanges();

        }
    }
}
