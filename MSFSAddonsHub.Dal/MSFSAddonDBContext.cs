using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSFSAddons.Models;
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

        
        public DbSet<AirPort> Airport { get; set; }

        public DbSet<MyAddon> UserAddons { get; set; }
        public DbSet<FileManger> FileManager { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightRoutes> FlightsRoutes { get; set; }

         public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubDownloads> ClubsDownloads { get; set; }
        public DbSet<ClubInvites> ClubInvites { get; set; }
        public DbSet<FriendRequest> FriendsRequest { get; set; }

        public DbSet<Friends> Friends { get; set; }
        public DbSet<ClubUsers> ClubUsers { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }
        public DbSet<MyDashBoard> MyDashBoard { get; set; }
        public DbSet<Credits> Credits { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public virtual IEnumerable<ApplicationUser> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Club>().Property(x => x.ClubId).HasDefaultValueSql("NEWID()");
       
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            


        }
        public void AddSubscriber (Subscriber sub)

        {
            this.Add(sub);
            this.SaveChanges();

        }
    }
}
