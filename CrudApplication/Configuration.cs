using Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;
using AutoMapper;

namespace CrudApplication
{
    public static class Configuration
    {
        public static void Configurate(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Configuration));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IUserProfileServices, UserProfileServices>();
            services.AddDbContext<CrudApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CrudApplication")));
            
        }
    }
}
