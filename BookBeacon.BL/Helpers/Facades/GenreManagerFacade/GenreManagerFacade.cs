using BookBeacon.BL.DTOs.GenreDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.GenreManagerFacade;

public class GenreManagerFacade : IGenreManagerFacade
{
    public IUnitOfWork UnitOfWork { get; }
    public IGenreRepository GenreRepository { get; }
    public IValidator<GenreDto> GenreValidator { get; }
    
    public GenreManagerFacade(
        IUnitOfWork unitOfWork,
        IGenreRepository genreRepository,
        IValidator<GenreDto> genreValidator)
    {
        UnitOfWork = unitOfWork;
        GenreRepository = genreRepository;
        GenreValidator = genreValidator;
    }
}
