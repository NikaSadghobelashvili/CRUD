using Microsoft.EntityFrameworkCore;
using Repository;

namespace CrudApplication
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly CrudApplicationDbContext _dbcontext;

        public Startup(IConfiguration configuration, CrudApplicationDbContext dbcontext)
        {
            _configuration = configuration;
            _dbcontext = dbcontext;
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CrudApplicationDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("CrudApplication")));
            
        }
    }
}
