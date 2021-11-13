using lega.Core.Entities;
using lega.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lega.Core
{
    public static partial class ServicesInitializer
    {
        public static void ConfigureDbContext(IConfiguration configuration, IServiceCollection services)
        {


            services.AddDbContextPool<AppDbContext>(
              options => options.UseSqlServer(configuration.GetConnectionString("AppDbConnection")));


            //services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<PecMembersDbContext>();


        }

        public static void ConfigureServices(IServiceCollection services)
        {
             services.AddTransient(typeof(IRepositories<>), typeof(Repositories<>));
             services.AddTransient<IUserRepasitory, UserRepasitory>();
             services.AddTransient<ICarouselRepasitory, CarouselRepasitory>();

            
        }
    }
}
