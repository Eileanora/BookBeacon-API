using System.Text;
using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Helpers.Facades.AuthorManagerFacade;
using BookBeacon.BL.Helpers.Facades.BookManagerFacade;
using BookBeacon.BL.Helpers.Facades.CopyManagerFacade;
using BookBeacon.BL.Helpers.Facades.GenreManagerFacade;
using BookBeacon.BL.Helpers.Facades.ReservationManagerFacade;
using BookBeacon.BL.Managers.AuthorManager;
using BookBeacon.BL.Managers.BookManager;
using BookBeacon.BL.Managers.CopyManager;
using BookBeacon.BL.Managers.GenreManager;
using BookBeacon.BL.Managers.JwtTokenManager;
using BookBeacon.BL.Managers.ReservationManager;
using BookBeacon.BL.Services.AuthService;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookBeacon.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddBlServices(this IServiceCollection services)
    {
        services.AddScoped<IGenreManagerFacade, GenreManagerFacade>();
        services.AddScoped<IGenreManager, GenreManager>();
        services.AddScoped<IAuthorManagerFacade, AuthorManagerFacade>();
        services.AddScoped<IAuthorManager, AuthorManager>();
        services.AddScoped<IBookManagerFacade, BookManagerFacade>();
        services.AddScoped<IBookManager, BookManager>();
        services.AddScoped<IReservationManagerFacade, ReservationManagerFacade>();
        services.AddScoped<IReservationManager, ReservationManager>();
        services.AddScoped<IJwtTokenManager, JwtTokenManager>();
        services.AddScoped<ICopyManagerFacade, CopyManagerFacade>();
        services.AddScoped<ICopyManager, CopyManager>();

        services.AddScoped<IAuthService, AuthService>();
        
        
        services.AddValidatorsFromAssemblyContaining<GenreDto>();
        services.AddValidatorsFromAssemblyContaining<AuthorDto>();
        services.AddValidatorsFromAssemblyContaining<BookDto>();
        
        
        return services;
    }
}