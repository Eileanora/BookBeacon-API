using BookBeacon.API.Helpers.ExceptionHandler;
using BookBeacon.API.Helpers.Facades.AuthorControllerFacade;
using BookBeacon.API.Helpers.Facades.BookControllerFacade;
using BookBeacon.API.Helpers.Facades.GenreControllerFacade;
using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.DTOs.BookDTOs;
using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.ResourceParameters;

namespace BookBeacon.API;

public static class DependencyInjection
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IPaginationHelper<GenreDto, GenreResourceParameters>, PaginationHelper<GenreDto, GenreResourceParameters>>();
        services.AddScoped<IPaginationHelper<AuthorDto, AuthorResourceParameters>, PaginationHelper<AuthorDto, AuthorResourceParameters>>();
        services.AddScoped<IPaginationHelper<BookDto, BookResourceParameters>, PaginationHelper<BookDto, BookResourceParameters>>();
        
        
        services.AddScoped<IGenreControllerFacade, GenreControllerFacade>();
        services.AddScoped<IAuthorControllerFacade, AuthorControllerFacade>();
        services.AddScoped<IBookControllerFacade, BookControllerFacade>();
        
        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddExceptionHandler<UnauthorizedAccessExceptionHandler>();
        services.AddProblemDetails();
    }
}
