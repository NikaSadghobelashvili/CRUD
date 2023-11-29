using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;

namespace CrudApplication
{
    public static class Configuration
    {
        public static void Configurate(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepository<User>,UserRepository>();
            services.AddDbContext<CrudApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CrudApplication")));
        }
    }
}
