using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sigim.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Sigim.Application.Models.Settings;
using Sigim.Application.Contracts.Infrastructure;
using Sigim.Infrastructure.Services;
using Complii.Application.Contracts.Infrastructure;
using Complii.Application.Contracts.Persistence;
using Sigim.Infrastructure.Repositories;

namespace Sigim.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            
            services.AddDbContext<SigimDbContext>(options =>
                options.UseNpgsql(connectionString, o2 =>
                {
                    o2.EnableRetryOnFailure(
                        maxRetryCount:10, 
                        maxRetryDelay: TimeSpan.FromSeconds(2),
                        errorCodesToAdd: null
                        );
                    o2.CommandTimeout(3600);
                }), ServiceLifetime.Transient);

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
                options.AddPolicy("Medico", policy => policy.RequireRole("Medico"));
                options.AddPolicy("Entrenador", policy => policy.RequireRole("Entrenador"));
                options.AddPolicy("Deportista", policy => policy.RequireRole("Deportista"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ICryptService, CryptService>();


            return services;
        }
    }
}
