using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.api;
using webapi.model;

namespace webapi.data
{
    public class ApplicationDBContext :IdentityDbContext<AppUser>
    {

        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }


        public DbSet<Comment> comments { get; set; }
        public DbSet<Stock> stocks { get; set; }

        public DbSet<Portfolio> portfolios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.appuserId, p.stockId }));

            builder.Entity<Portfolio>().HasOne(p=>p.appUser).WithMany(p=>p.portfolios).HasForeignKey(p=>p.appuserId);
            builder.Entity<Portfolio>().HasOne(p => p.stock).WithMany(p => p.portfolios).HasForeignKey(p => p.stockId);


            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
