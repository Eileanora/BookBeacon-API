using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Helpers.Facades.GenreManagerFacade;
using BookBeacon.BL.Managers.GenreManager;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BookBeacon.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddBlServices(this IServiceCollection services)
    {
        services.AddScoped<IGenreManagerFacade, GenreManagerFacade>();
        services.AddScoped<IGenreManager, GenreManager>();
        
        services.AddValidatorsFromAssemblyContaining<GenreDto>();
        
        
        return services;
    }
}