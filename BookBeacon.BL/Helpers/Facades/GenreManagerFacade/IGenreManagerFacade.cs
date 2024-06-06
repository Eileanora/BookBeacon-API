using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.GenreManagerFacade;

public interface IGenreManagerFacade
{
    IUnitOfWork UnitOfWork { get; }
    IGenreRepository GenreRepository { get; }
    IValidator<GenreDto> GenreValidator { get; }
}
