using BookBeacon.BL.DTOs.AuthorDTOs;
using BookBeacon.BL.Repositories;
using FluentValidation;

namespace BookBeacon.BL.Helpers.Facades.AuthorManagerFacade;

public interface IAuthorManagerFacade
{
    IUnitOfWork UnitOfWork { get; }
    IAuthorRepository AuthorRepository { get; }
    IValidator<AuthorDto> AuthorValidator { get; }
}
