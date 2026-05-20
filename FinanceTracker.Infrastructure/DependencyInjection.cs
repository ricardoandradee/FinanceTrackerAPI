using FinanceTracker.Application.Common.Interfaces;
using FinanceTracker.Application.Email;
using FinanceTracker.Application.Utils;
using FinanceTracker.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace FinanceTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionAzure");
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Configuration value 'ConnectionStrings:DefaultConnectionAzure' is missing. Set it in appsettings or environment variables.");

            var jwtKey = configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(jwtKey))
                throw new InvalidOperationException("Configuration value 'Jwt:Key' is missing. Set it in appsettings or environment variables.");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString,
                        b => b.MigrationsAssembly("FinanceTracker.API"));
                options.EnableSensitiveDataLogging();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddTransient<ApplicationDbContextSeed>();
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            var assembly = typeof(UnitOfWorkRepository).Assembly;
            var types = assembly.ExportedTypes.Where(x =>
                x.IsClass &&
                !x.IsGenericType &&
                x.IsPublic &&
                x.Name.Contains("Repository"));

            foreach (var type in types)
            {
                var repositoryType = type.GetInterface($"I{type.Name}");
                if (repositoryType != null)
                {
                    services.AddScoped(repositoryType, type);
                }
            }

            services.AddScoped<IEmailHandler, EmailHandler>();
            services.AddScoped<IFileHandler, FileHandler>();

            return services;
        }
    }
}
