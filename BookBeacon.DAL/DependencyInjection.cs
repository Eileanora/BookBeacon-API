using BookBeacon.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookBeacon.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddSingleton<UpdateAuditFieldsInterceptor>();
        services.AddDbContext<BookBeaconContext>((sp, options) =>
        {
            // var UpdateAuditFieldsInterceptor = sp.GetRequiredService<UpdateAuditFieldsInterceptor>();
            options.UseSqlServer(configuration.GetConnectionString("DevConnectionString"));
            // options.AddInterceptors(UpdateAuditFieldsInterceptor);
            options.EnableSensitiveDataLogging(); // Corrected line
        });
        return services;
    }
}
