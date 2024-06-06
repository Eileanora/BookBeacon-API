using BookBeacon.API.Helpers.PaginationHelper;
using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Managers.GenreManager;
using BookBeacon.BL.ResourceParameters;
using FluentValidation;

namespace BookBeacon.API.Helpers.Facades.GenreControllerFacade;

public interface IGenreControllerFacade
{
    IGenreManager GenreManager { get; }
    IValidator<GenreDto> GenreValidator { get; }
    IPaginationHelper<GenreDto, GenreResourceParameters> PaginationHelper { get; }
}
