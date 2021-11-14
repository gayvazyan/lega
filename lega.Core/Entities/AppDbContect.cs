using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Service> ServiceDb { get; set; }

    }
}
