using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Identity;
using Infrastructure.Interfaces;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IDateTime, DateTimeService>();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IHeaderRepository, HeaderRepository>();
            services.AddTransient<IDetailRepository, DetailRepository>();
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<IHeaderService, HeaderService>();

            return services;
        }
    }
}
