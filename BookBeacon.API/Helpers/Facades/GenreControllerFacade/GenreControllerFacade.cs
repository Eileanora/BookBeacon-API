using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Managers.GenreManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.GenreControllerFacade;

public class GenreControllerFacade : IGenreControllerFacade
{
    public IGenreManager GenreManager { get; }
    public IValidator<GenreDto> GenreValidator { get; }
    public IPaginationHelper<GenreDto, GenreResourceParameters> PaginationHelper { get; }
    
    public GenreControllerFacade(
        IGenreManager genreManager,
        IValidator<GenreDto> genreValidator,
        IPaginationHelper<GenreDto, GenreResourceParameters> paginationHelper)
    {
        GenreManager = genreManager;
        GenreValidator = genreValidator;
        PaginationHelper = paginationHelper;
    }
}
