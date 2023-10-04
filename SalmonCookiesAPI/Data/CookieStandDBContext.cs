using Microsoft.EntityFrameworkCore;
using SalmonCookiesAPI.Models;

namespace SalmonCookiesAPI.Data
{
    public class CookieStandDBContext : DbContext
    {



        public CookieStandDBContext(DbContextOptions<CookieStandDBContext> options) : base(options)
        {

        }



        public DbSet<CookieStand> CookieStands { get; set; }

        public DbSet<HourlySale> hourlySale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            var cookieStands = new List<CookieStand>
        {
            new CookieStand
            {
                Id=1,
                Location = "Amman",
                Description = "description1",
                MinimumCustomersPerHour = 3,
                MaximumCustomersPerHour = 7,
                AverageCookiesPerSale = 2.5,
                Owner = "Person1"
            },
            new CookieStand
            {
                Id=2,
                Location = "Irbid",
                Description = "description2",
                MinimumCustomersPerHour = 3,
                MaximumCustomersPerHour = 7,
                AverageCookiesPerSale = 2.5,
                Owner = "Person2"
            }
        };

            // Add the data to the context
            modelBuilder.Entity<CookieStand>().HasData(cookieStands);

            modelBuilder.Entity<CookieStand>()
     .HasKey(c => c.Id);
        }



    }
}
