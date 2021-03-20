using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MSFSClubManager.Models;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;

namespace MSFSClubManager.Dal
{
    public class MSFSClubManagerDBContext : IdentityDbContext<ApplicationUser>
    {
        public MSFSClubManagerDBContext(DbContextOptions<MSFSClubManagerDBContext> options)
        : base(options)
        {

        }


        public DbSet<AirPort> Airport { get; set; }

        public DbSet<Mods> Mods { get; set; }
        public DbSet<FileManger> FileManager { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightRoutes> FlightsRoutes { get; set; }


        public DbSet<Pilot> Pilots { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<SocialMediaLinks> SocialMediaLinks { get; set; }
        public DbSet<ClubDownloads> ClubsDownloads { get; set; }
        public DbSet<ClubInvites> ClubInvites { get; set; }
        public DbSet<FriendRequest> FriendsRequest { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<SubscriptionTeirs> SubscriptionTeirs { get; set; }
        public DbSet<SubscriptionTierTypes> SubscriptionTierTypes { get; set; }
        public DbSet<SubscriptionTypesBalances> SubscriptionTypesBalances { get; set; }

        public DbSet<Friends> Friends { get; set; }
        public DbSet<ClubMembers> ClubMembers { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }
        public DbSet<MyDashBoard> MyDashBoard { get; set; }
        public DbSet<Credits> Credits { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public virtual IEnumerable<ApplicationUser> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Club>().Property(x => x.ClubId).HasDefaultValueSql("NEWID()");


            //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ClubSuperAdmin", NormalizedName = "SuperAdmin".ToUpper() });
            //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ClubMod", NormalizedName = "ClubMod".ToUpper() });
            //    modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "ClubUser", NormalizedName = "ClubUser".ToUpper() });

            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new TestUser1Seeder());
            modelBuilder.ApplyConfiguration(new TestUser2Seeder());

            //modelBuilder.ApplyConfiguration(new UsersWithRolesConfig());


        }




        public void AddSubscriber(Subscriber sub)

        {
            this.Add(sub);
            this.SaveChanges();

        }
    }
}
