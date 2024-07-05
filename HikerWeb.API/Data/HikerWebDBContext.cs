using HikerWeb.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace HikerWeb.API.Data
{
    public class HikerWebDBContext : DbContext
    {
        public HikerWebDBContext(DbContextOptions<HikerWebDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<PictureLink> PictureLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActivityType>().HasData(
                new ActivityType
                {
                    Id = 1,
                    Type = "Hiking"
                });

            modelBuilder.Entity<ActivityType>().HasData(
            new ActivityType
            {
                Id = 2,
                Type = "Running"
            });
            modelBuilder.Entity<ActivityType>().HasData(
            new ActivityType
            {
                Id = 3,
                Type = "Biking"
            });



        }
    }
}
