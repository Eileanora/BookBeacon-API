using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.AuthorManagerFacade;

public class AuthorManagerFacade : IAuthorManagerFacade
{
    public IUnitOfWork UnitOfWork { get; }
    public IAuthorRepository AuthorRepository { get; }
    public IValidator<AuthorDto> AuthorValidator { get; }
    
    public AuthorManagerFacade(
        IUnitOfWork unitOfWork,
        IAuthorRepository authorRepository,
        IValidator<AuthorDto> authorValidator)
    {
        UnitOfWork = unitOfWork;
        AuthorRepository = authorRepository;
        AuthorValidator = authorValidator;
    }
}
