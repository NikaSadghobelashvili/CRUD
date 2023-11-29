using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

namespace CrudApplication
{
    public static class Configuration
    {
        public static void Configurate(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IUserProfileServices, UserProfileServices>();
            services.AddDbContext<CrudApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CrudApplication")));
        }
    }
}
