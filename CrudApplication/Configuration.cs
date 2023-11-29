﻿using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Services;

namespace CrudApplication
{
    public static class Configuration
    {
        public static void Configurate(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServices<User>, UserServices>();
            services.AddScoped<IServices<UserProfile>, UserProfileServices>();
            services.AddDbContext<CrudApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CrudApplication")));
        }
    }
}
