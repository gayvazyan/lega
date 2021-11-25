using Microsoft.EntityFrameworkCore;


namespace lega.Core.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Users> UsersDb { get; set; }
        public DbSet<Carousel> CarouselDb { get; set; }
        public DbSet<About> AboutDb { get; set; }
        public DbSet<Pricing> PricingDb { get; set; }
        public DbSet<Service> ServiceDb { get; set; }
        public DbSet<Customer> CustomerDb { get; set; }
        public DbSet<News> NewsDb { get; set; }

    }
}
