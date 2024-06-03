using BookBeacon.BL.Repositories;
using BookBeacon.DAL.Context;
using BookBeacon.DAL.Helpers.SortHelper;
using BookBeacon.DAL.Repositories;
using BookBeacon.Models.Models;
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

        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISortHelper<Genre>, SortHelper<Genre>>();
        services.AddScoped<ISortHelper<Author>, SortHelper<Author>>();
        services.AddScoped<ISortHelper<Book>, SortHelper<Book>>();

        
        return services;
    }
}
