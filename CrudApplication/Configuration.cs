using Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Services;
using System.Text;


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
            services.AddTransient<ITokenService, TokenService>();
            services.AddDbContext<CrudApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CrudApplication")));
            ConfigurateToken(services);
            ConfigureServices(services);
        }
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Your API",
                    Version = "v1",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });

        }
        public static void ConfigurateToken(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your_issuer",
                    ValidAudience = "your_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_that_is_at_least_128_bits_long_xxxxxxxxxx")),

                };
            });
        }
    }
}
